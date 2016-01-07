using System;
using System.Reflection;
using System.Configuration;
namespace PZYM.Shop.DALFactory
{
    /// <summary>
    /// Abstract Factory pattern to create the DAL��
    /// ��������ﴴ�����󱨴�����web.config���Ƿ��޸���<add key="DAL" value="Maticsoft.SQLServerDAL" />��
    /// </summary>
    public sealed class DataAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        public DataAccess()
        { }

        #region CreateObject 

        //��ʹ�û���
        private static object CreateObjectNoCache(string AssemblyPath, string classNamespace)
        {
            try
            {
                object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                return objType;
            }
            catch//(System.Exception ex)
            {
                //string str=ex.Message;// ��¼������־
                return null;
            }

        }
        //ʹ�û���
        private static object CreateObject(string AssemblyPath, string classNamespace)
        {
            object objType = DataCache.GetCache(classNamespace);
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                    DataCache.SetCache(classNamespace, objType);// д�뻺��
                }
                catch//(System.Exception ex)
                {
                    //string str=ex.Message;// ��¼������־
                }
            }
            return objType;
        }
        #endregion

        #region CreateSysManage
        public static PZYM.Shop.IDAL.ISysManage CreateSysManage()
        {
            //��ʽ1			
            //return (PZYM.Shop.IDAL.ISysManage)Assembly.Load(AssemblyPath).CreateInstance(AssemblyPath+".SysManage");

            //��ʽ2 			
            string classNamespace = AssemblyPath + ".SysManage";
            object objType = CreateObject(AssemblyPath, classNamespace);
            return (PZYM.Shop.IDAL.ISysManage)objType;
        }
        #endregion



        /// <summary>
        /// ����BooksServices���ݲ�ӿڡ�
        /// </summary>
        public static PZYM.Shop.IDAL.IBooksServices CreateBooksServices()
        {

            string ClassNamespace = AssemblyPath + ".BooksServices";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (PZYM.Shop.IDAL.IBooksServices)objType;
        }

    }
}