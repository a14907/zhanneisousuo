using System;
using System.Data;
namespace PZYM.Shop.IDAL
{
	/// <summary>
	/// �ӿڲ�IBooksServices 
	/// </summary>
	public interface IBooksServices
	{
		#region  ��Ա����
		/// <summary>
		/// �õ����ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int Id);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(PZYM.Shop.Model.Books model);
		/// <summary>
		/// ����һ������
		/// </summary>
		bool Update(PZYM.Shop.Model.Books model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		bool Delete(int Id);
		bool DeleteList(string Idlist );
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		PZYM.Shop.Model.Books GetModel(int Id);
		/// <summary>
		/// ��������б�
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		/// <summary>
		/// ���ݷ�ҳ��������б�
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  ��Ա����
	}
}
