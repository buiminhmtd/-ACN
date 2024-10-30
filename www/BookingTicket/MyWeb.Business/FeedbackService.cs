using System.Data;
using MyWeb.Data;

namespace MyWeb.Business
{
	public class FeedbackService
	{
		private static readonly FeedbackDAL db = new FeedbackDAL();
		#region[Feedback_GetById]
		public static DataTable Feedback_GetById(string Id)
		{
			return db.Feedback_GetById(Id);
		}
		#endregion
		#region[Feedback_GetByAll]
		public static DataTable Feedback_GetByAll()
		{
			return db.Feedback_GetByAll();
		}
		#endregion
		#region[Feedback_GetByTop]
		public static DataTable Feedback_GetByTop(string Top, string Where, string Order)
		{
			return db.Feedback_GetByTop(Top, Where, Order);}
		#endregion
		#region[Feedback_Insert]
		public static void Feedback_Insert(FeedbackInfo Data)
		{
			 db.Feedback_Insert(Data);
		}
		#endregion
		#region[Feedback_Update]
		public static void Feedback_Update(FeedbackInfo Data)
		{
			 db.Feedback_Update(Data);
		}
		#endregion
		#region[Feedback_Delete]
		public static void Feedback_Delete(string Id)
		{
			 db.Feedback_Delete(Id);
		}
		#endregion
		#region[Feedback_GetByFilId]
		public static DataTable Feedback_GetByFilId(string FilId)
		{
			 return db.Feedback_GetByFilId(FilId);
		}
		#endregion
	}
}