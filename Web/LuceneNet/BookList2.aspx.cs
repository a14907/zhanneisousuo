using System;
using System.Collections.Generic;
using System.IO;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using PZYM.Shop.BLL;
using PZYM.Shop.Model;

namespace Web.LuceneNet {
    public partial class BookList2 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            string btnInsert = Request.QueryString["btnInsert"];
            string btnSearch = Request.QueryString["btnSearch"];
            if(!string.IsNullOrEmpty(btnInsert)) {
                //数据新增至索引库
                InsertToIndex();
            }
            if(!string.IsNullOrEmpty(btnSearch)) {
                //搜索
                SearchFromIndexData();
            }
        }

        //临时数据代替表单提交
        private void InsertToIndex() {
            //创建一条临时数据
            Books book = new Books();
            book.Author = "痞子一毛";
            book.Title = "piziyimao";
            book.CategoryId = 1;
            book.ContentDescription = "不是所有痞子都叫一毛不是所有痞子都叫一毛不是所有痞子都叫一毛不是所有痞子都叫一毛";
            book.PublisherId = 1;
            book.ISBN = "124365";
            book.WordsCount = 1000000;
            book.UnitPrice = 88;
            book.CategoryId = 1;
            book.Clicks = 10;
            book.PublishDate = DateTime.Now;
            BooksManager bm = new BooksManager();
            //IndexManager.bookIndex.Add()数据新增 索引库更新测试

            //int insertId;
            //if((insertId = bm.Add(book)) > 0) {
            //    book.Id = insertId;
            //    IndexManager.bookIndex.Add(book);
            //}

            //IndexManager.bookIndex.Mod()数据修改 索引库更新测试
            book.Id = 10001;//数据库生成主键ID
            book.ContentDescription = "侬好哇, 记住不是所有痞子都叫一毛哟";
            bm.Update(book);
            IndexManager.bookIndex.Mod(book);
        }

        /// <summary>
        /// 从索引库中检索关键字
        /// </summary>
        private void SearchFromIndexData() {
            string indexPath = Context.Server.MapPath("~/IndexData");
            FSDirectory directory = FSDirectory.Open(new DirectoryInfo(indexPath), new NoLockFactory());
            IndexReader reader = IndexReader.Open(directory, true);
            IndexSearcher searcher = new IndexSearcher(reader);

            //--------------------------------------这里配置搜索条件
            //PhraseQuery query = new PhraseQuery();
            //foreach(string word in Common.SplitContent.SplitWords(Request.QueryString["SearchKey"])) {
            //    query.Add(new Term("content", word));//这里是 and关系
            //}
            //query.SetSlop(100);

            //关键词Or关系设置
            BooleanQuery queryOr = new BooleanQuery();
            TermQuery query = null;
            foreach(string word in Common.SplitContent.SplitWords(Request.QueryString["SearchKey"])) {
                query = new TermQuery(new Term("content", word));
                queryOr.Add(query, BooleanClause.Occur.SHOULD);//这里设置 条件为Or关系
            }
            //--------------------------------------
            TopScoreDocCollector collector = TopScoreDocCollector.create(1000, true);
            //searcher.Search(query, null, collector);
            searcher.Search(queryOr, null, collector);


            ScoreDoc[] docs = collector.TopDocs(0, 10).scoreDocs;//取前十条数据  可以通过它实现LuceneNet搜索结果分页
            List<PZYM.Shop.Model.Books> bookResult = new List<PZYM.Shop.Model.Books>();
            for(int i = 0; i < docs.Length; i++) {
                int docId = docs[i].doc;
                Document doc = searcher.Doc(docId);

                PZYM.Shop.Model.Books book = new PZYM.Shop.Model.Books();
                book.Title = doc.Get("title");
                book.ContentDescription = Common.SplitContent.HightLight(Request.QueryString["SearchKey"], doc.Get("content"));
                book.Id = Convert.ToInt32(doc.Get("id"));
                bookResult.Add(book);
            }
            Repeater1.DataSource = bookResult;
            Repeater1.DataBind();
        }
    }
}