using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Nagarro.EmployeePortal.DAL;

namespace Nagarro.EmployeePortal.BLL
{
    public class NoticeList : List<Notice>
    {
        private NoticeList()
        {
        }

        public static NoticeList GetAllNotices()
        {
            NoticeList list = new NoticeList();
			list.FetchAll();
            return list;
        }

		public static NoticeList GetActiveNotices()
		{
			NoticeList list = new NoticeList();
			list.FetchActive();
			return list;
		}

		private void FetchActive()
		{
			//TODO:
		}

		private void FetchAll()
		{
			List<NoticeManager.Notice> allNotices = NoticeManager.GetAllNotices();

			foreach (var item in allNotices)
			{
				Notice notice = Notice.GetNotice(item);
				this.Add(notice);
			}
		}
    }
}
