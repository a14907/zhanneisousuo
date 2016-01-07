using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;//Please add references
using PZYM.Shop.IDAL;
namespace PZYM.Shop.SQLServerDAL {
    /// <summary>
    /// ���ݷ�����:BooksServices
    /// </summary>
    public partial class BooksServices : IBooksServices {
        public BooksServices() {
        }
        #region  Method

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId() {
            return DbHelperSQL.GetMaxID("Id", "Books");
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int Id) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Books");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(PZYM.Shop.Model.Books model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Books(");
            strSql.Append("Title,Author,PublisherId,PublishDate,ISBN,WordsCount,UnitPrice,ContentDescription,AurhorDescription,EditorComment,TOC,CategoryId,Clicks)");
            strSql.Append(" values (");
            strSql.Append("@Title,@Author,@PublisherId,@PublishDate,@ISBN,@WordsCount,@UnitPrice,@ContentDescription,@AurhorDescription,@EditorComment,@TOC,@CategoryId,@Clicks)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@Author", SqlDbType.NVarChar,200),
					new SqlParameter("@PublisherId", SqlDbType.Int,4),
					new SqlParameter("@PublishDate", SqlDbType.DateTime),
					new SqlParameter("@ISBN", SqlDbType.NVarChar,50),
					new SqlParameter("@WordsCount", SqlDbType.Int,4),
					new SqlParameter("@UnitPrice", SqlDbType.Money,8),
					new SqlParameter("@ContentDescription", SqlDbType.NVarChar),
					new SqlParameter("@AurhorDescription", SqlDbType.NVarChar),
					new SqlParameter("@EditorComment", SqlDbType.NVarChar),
					new SqlParameter("@TOC", SqlDbType.NVarChar),
					new SqlParameter("@CategoryId", SqlDbType.Int,4),
					new SqlParameter("@Clicks", SqlDbType.Int,4)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Author;
            parameters[2].Value = model.PublisherId;
            parameters[3].Value = model.PublishDate;
            parameters[4].Value = model.ISBN;
            parameters[5].Value = model.WordsCount;
            parameters[6].Value = model.UnitPrice;
            parameters[7].Value = model.ContentDescription;
            parameters[8].Value = model.AurhorDescription;
            parameters[9].Value = model.EditorComment;
            parameters[10].Value = model.TOC;
            parameters[11].Value = model.CategoryId;
            parameters[12].Value = model.Clicks;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if(obj == null) {
                return 0;
            } else {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(PZYM.Shop.Model.Books model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Books set ");
            strSql.Append("Title=@Title,");
            strSql.Append("Author=@Author,");
            strSql.Append("PublisherId=@PublisherId,");
            strSql.Append("PublishDate=@PublishDate,");
            strSql.Append("ISBN=@ISBN,");
            strSql.Append("WordsCount=@WordsCount,");
            strSql.Append("UnitPrice=@UnitPrice,");
            strSql.Append("ContentDescription=@ContentDescription,");
            strSql.Append("AurhorDescription=@AurhorDescription,");
            strSql.Append("EditorComment=@EditorComment,");
            strSql.Append("TOC=@TOC,");
            strSql.Append("CategoryId=@CategoryId,");
            strSql.Append("Clicks=@Clicks");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@Author", SqlDbType.NVarChar,200),
					new SqlParameter("@PublisherId", SqlDbType.Int,4),
					new SqlParameter("@PublishDate", SqlDbType.DateTime),
					new SqlParameter("@ISBN", SqlDbType.NVarChar,50),
					new SqlParameter("@WordsCount", SqlDbType.Int,4),
					new SqlParameter("@UnitPrice", SqlDbType.Money,8),
					new SqlParameter("@ContentDescription", SqlDbType.NVarChar),
					new SqlParameter("@AurhorDescription", SqlDbType.NVarChar),
					new SqlParameter("@EditorComment", SqlDbType.NVarChar),
					new SqlParameter("@TOC", SqlDbType.NVarChar),
					new SqlParameter("@CategoryId", SqlDbType.Int,4),
					new SqlParameter("@Clicks", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Author;
            parameters[2].Value = model.PublisherId;
            parameters[3].Value = model.PublishDate;
            parameters[4].Value = model.ISBN;
            parameters[5].Value = model.WordsCount;
            parameters[6].Value = model.UnitPrice;
            parameters[7].Value = model.ContentDescription;
            parameters[8].Value = model.AurhorDescription;
            parameters[9].Value = model.EditorComment;
            parameters[10].Value = model.TOC;
            parameters[11].Value = model.CategoryId;
            parameters[12].Value = model.Clicks;
            parameters[13].Value = model.Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if(rows > 0) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int Id) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Books ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
            parameters[0].Value = Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if(rows > 0) {
                return true;
            } else {
                return false;
            }
        }
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool DeleteList(string Idlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Books ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if(rows > 0) {
                return true;
            } else {
                return false;
            }
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public PZYM.Shop.Model.Books GetModel(int Id) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Title,Author,PublisherId,PublishDate,ISBN,WordsCount,UnitPrice,ContentDescription,AurhorDescription,EditorComment,TOC,CategoryId,Clicks from Books ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
            parameters[0].Value = Id;

            PZYM.Shop.Model.Books model = new PZYM.Shop.Model.Books();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if(ds.Tables[0].Rows.Count > 0) {
                if(ds.Tables[0].Rows[0]["Id"].ToString() != "") {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Author = ds.Tables[0].Rows[0]["Author"].ToString();
                if(ds.Tables[0].Rows[0]["PublisherId"].ToString() != "") {
                    model.PublisherId = int.Parse(ds.Tables[0].Rows[0]["PublisherId"].ToString());
                }
                if(ds.Tables[0].Rows[0]["PublishDate"].ToString() != "") {
                    model.PublishDate = DateTime.Parse(ds.Tables[0].Rows[0]["PublishDate"].ToString());
                }
                model.ISBN = ds.Tables[0].Rows[0]["ISBN"].ToString();
                if(ds.Tables[0].Rows[0]["WordsCount"].ToString() != "") {
                    model.WordsCount = int.Parse(ds.Tables[0].Rows[0]["WordsCount"].ToString());
                }
                if(ds.Tables[0].Rows[0]["UnitPrice"].ToString() != "") {
                    model.UnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["UnitPrice"].ToString());
                }
                model.ContentDescription = ds.Tables[0].Rows[0]["ContentDescription"].ToString();
                model.AurhorDescription = ds.Tables[0].Rows[0]["AurhorDescription"].ToString();
                model.EditorComment = ds.Tables[0].Rows[0]["EditorComment"].ToString();
                model.TOC = ds.Tables[0].Rows[0]["TOC"].ToString();
                if(ds.Tables[0].Rows[0]["CategoryId"].ToString() != "") {
                    model.CategoryId = int.Parse(ds.Tables[0].Rows[0]["CategoryId"].ToString());
                }
                if(ds.Tables[0].Rows[0]["Clicks"].ToString() != "") {
                    model.Clicks = int.Parse(ds.Tables[0].Rows[0]["Clicks"].ToString());
                }
                return model;
            } else {
                return null;
            }
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Title,Author,PublisherId,PublishDate,ISBN,WordsCount,UnitPrice,ContentDescription,AurhorDescription,EditorComment,TOC,CategoryId,Clicks ");
            strSql.Append(" FROM Books ");
            if(!string.IsNullOrEmpty(strWhere)) {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if(Top > 0) {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id,Title,Author,PublisherId,PublishDate,ISBN,WordsCount,UnitPrice,ContentDescription,AurhorDescription,EditorComment,TOC,CategoryId,Clicks ");
            strSql.Append(" FROM Books ");
            if(!string.IsNullOrEmpty(strWhere)) {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// ��ҳ��ȡ�����б�
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Books";
            parameters[1].Value = "Id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}
