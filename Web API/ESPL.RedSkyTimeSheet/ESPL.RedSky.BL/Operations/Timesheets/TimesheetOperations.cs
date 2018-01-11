using ESPL.RedSkyTimeSheet.BL.Models;
using ESPL.RedSkyTimeSheet.BL.Operations.Common;
using ESPL.RedSkyTimeSheet.DAL;
using ESPL.RedSkyTimeSheet.Lists;
using ESPL.RedSkyTimeSheet.ViewModel.GenericViewModel;
using ESPL.RedSkyTimeSheet.ViewModel.TimesheetModel;
using ESPL.SHAREPOINT.RESTSERVICE;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ESPL.RedSkyTimeSheet.BL.Operations.Timesheets
{
    public class TimesheetOperations
    {
        /// <summary>
        /// Get All Timesheets
        /// </summary>
        /// <param name="id"></param>
        /// <param name="siteUrl"></param>
        /// <returns></returns>
        public List<TimesheetWithWorkItems> GetTimesheetItems(string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.Timesheet, true),
                                                    string.Format(Lists.RestFilters.topItems, GetTop.Default));
                return GetWorkItemsByTimesheetRestURL(RestUrl, siteUrl);
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        /// <summary>
        /// Get Timesheets by SharePoint ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="siteUrl"></param>
        /// <returns></returns>
        public List<TimesheetWithWorkItems> GetTimesheetByID(string id, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.Timesheet, true),
                                                    string.Format(RestFilters.ByID, id), string.Format(Lists.RestFilters.topItems, GetTop.Default));

                return GetWorkItemsByTimesheetRestURL(RestUrl, siteUrl);
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        /// <summary>
        /// Get Timesheets by Salesforce Record ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="siteUrl"></param>
        /// <returns></returns>
        public List<TimesheetWithWorkItems> GetTimesheetByRecordID(string id, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.Timesheet, true),
                                                    string.Format(RestFilters.ByRecordID, id), string.Format(Lists.RestFilters.topItems, GetTop.Default));

                return GetWorkItemsByTimesheetRestURL(RestUrl, siteUrl);
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        /// <summary>
        /// Get all Timesheets by Status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="siteUrl"></param>
        /// <returns></returns>
        public List<TimesheetWithWorkItems> GetTimesheetByStatus(string status, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.Timesheet, true),
                                                    string.Format(RestFilters.ByStatus, status), string.Format(Lists.RestFilters.topItems, GetTop.Default));

                return GetWorkItemsByTimesheetRestURL(RestUrl, siteUrl);
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        /// <summary>
        /// Get all Timesheets by Sync Status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="siteUrl"></param>
        /// <returns></returns>
        public List<TimesheetWithWorkItems> GetTimesheetBySyncStatus(int syncStatus, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.Timesheet, true),
                                                    string.Format(RestFilters.BySyncStatus, syncStatus), string.Format(Lists.RestFilters.topItems, GetTop.Default));

                return GetWorkItemsByTimesheetRestURL(RestUrl, siteUrl);
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        /// <summary>
        /// Get all Timesheets by Employee, WeekStartDate and Status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="siteUrl"></param>
        /// <returns></returns>
        public List<TimesheetWithWorkItems> GetTimesheetsByEmployeeAndWeekStartDateAndStatus(TimesheetByEmployeeAndStartDateAndStatusViewModel timesheetObj, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.Timesheet, true),
                                                    string.Format(RestFilters.ByEmployeeAndStartDateAndStatus, timesheetObj.Employee.ID, timesheetObj.WeekStartDate.ToString("yyyy-MM-ddTHH:mm:ssZ"), timesheetObj.Status), string.Format(Lists.RestFilters.topItems, GetTop.Default));

                return GetWorkItemsByTimesheetRestURL(RestUrl, siteUrl);
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        /// <summary>
        ///  Get all Timesheets by Employee, WeekStartDate
        /// </summary>
        /// <param name="id"></param>
        /// <param name="siteUrl"></param>
        /// <returns></returns>
        public List<TimesheetWithWorkItems> GetTimesheetsByEmployeeAndWeekStartDate(TimesheetByEmployeeAndStartDateAndStatusViewModel timesheetObj, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.Timesheet, true),
                                                    string.Format(RestFilters.ByEmployeeAndStartDate, timesheetObj.Employee.ID, timesheetObj.WeekStartDate.ToString("yyyy-MM-ddTHH:mm:ssZ")), string.Format(Lists.RestFilters.topItems, GetTop.Default));

                return GetWorkItemsByTimesheetRestURL(RestUrl, siteUrl);
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        /// <summary>
        ///  Get all Timesheets by Employee and Status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="siteUrl"></param>
        /// <returns></returns>
        public List<TimesheetWithWorkItems> GetTimesheetsByEmployeeAndStatus(TimesheetByEmployeeAndStartDateAndStatusViewModel timesheetObj, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.Timesheet, true),
                                                    string.Format(RestFilters.ByEmployeeAndStatus, timesheetObj.Employee.ID, timesheetObj.Status), string.Format(Lists.RestFilters.topItems, GetTop.Default));

                return GetWorkItemsByTimesheetRestURL(RestUrl, siteUrl);
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        /// <summary>
        ///Get all Timesheets by WeekStartDate and Status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="siteUrl"></param>
        /// <returns></returns>
        public List<TimesheetWithWorkItems> GetTimesheetsByWeekStartDateAndStatus(TimesheetByEmployeeAndStartDateAndStatusViewModel timesheetObj, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.Timesheet, true),
                                                    string.Format(RestFilters.ByStartDateAndStatus, timesheetObj.WeekStartDate.ToString("yyyy-MM-ddTHH:mm:ssZ"), timesheetObj.Status), string.Format(Lists.RestFilters.topItems, GetTop.Default));

                return GetWorkItemsByTimesheetRestURL(RestUrl, siteUrl);
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        /// <summary>
        /// Get all Timesheets by WeekStartDate
        /// </summary>
        /// <param name="id"></param>
        /// <param name="siteUrl"></param>
        /// <returns></returns>
        public List<TimesheetWithWorkItems> GetTimesheetsByWeekStartDate(TimesheetByEmployeeAndStartDateAndStatusViewModel timesheetObj, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.Timesheet, true),
                                                    string.Format(RestFilters.ByStartDate, timesheetObj.WeekStartDate.ToString("yyyy-MM-ddTHH:mm:ssZ")), string.Format(Lists.RestFilters.topItems, GetTop.Default));

                return GetWorkItemsByTimesheetRestURL(RestUrl, siteUrl);
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        public List<TimesheetWithWorkItems> GetWorkItemsByTimesheetRestURL(string RestUrl, string siteUrl)
        {
            WorkItemsOperations objWorkItems = new WorkItemsOperations();
            List<TimesheetWithWorkItems> timesheetWorkItems = new List<TimesheetWithWorkItems>();
            timesheetWorkItems = CRUDOperations.GetListByRestURL<TimesheetWithWorkItems>(RestUrl);
            foreach (TimesheetWithWorkItems timesheetItem in timesheetWorkItems)
            {
                List<WorkItems> workItems = objWorkItems.GetWorkItemsByTimesheetID(Convert.ToString(timesheetItem.ID), siteUrl);
                timesheetItem.WorkItems = workItems;
            }
            return timesheetWorkItems;

        }

        public Result UpdateTimesheetRecordId(List<SyncRecordID> objRecordIDs, string siteUrl)
        {
            Result res = new Result();
            try
            {
                Timesheet objTimesheet = new Timesheet();
                int recordsUpdatedCounter = 0;
                foreach (var _recordIDObj in objRecordIDs)
                {
                    Result updateResult = new Result();
                    objTimesheet.ID = _recordIDObj.ID;
                    objTimesheet.RecordID = _recordIDObj.RecordID;
                    updateResult = UpdateTimesheet(objTimesheet, siteUrl);
                    if (updateResult.StatusCode.Equals(1))
                        recordsUpdatedCounter++;
                }
                res.StatusCode = StatusCode.Success;
                res.Message = recordsUpdatedCounter + " " + Messages.MsgSuccessRecordsUpdate;
                return res;
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                res.Message = Messages.MsgSomethingWentWrong;
                res.StatusCode = StatusCode.Error;
                return res;
            }
        }

        public Result UpdateTimesheetRecordIdByEmployeeAndWeekStartDate(TimesheetByEmployeeAndStartDateAndStatusViewModel objTimesheetRecord, string siteUrl)
        {
            Result res = new Result();
            try
            {

                List<TimesheetWithWorkItems> objTimesheetList = GetTimesheetsByEmployeeAndWeekStartDate(objTimesheetRecord, siteUrl);
                foreach (var _recordIDObj in objTimesheetList)
                {
                    Timesheet objTimesheet = new Timesheet();
                    objTimesheet.ID = _recordIDObj.ID;
                    objTimesheet.RecordID = objTimesheetRecord.RecordID;
                    UpdateTimesheet(objTimesheet, siteUrl);
                }
                res.StatusCode = StatusCode.Success;
                res.Message = Messages.MsgSuccessUpdate;
                return res;
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                res.Message = Messages.MsgSomethingWentWrong;
                res.StatusCode = StatusCode.Error;
                return res;
            }
        }

        /// <summary>
        /// Update Timesheets into database
        /// </summary>
        /// <param name="objTimesheets">Timesheet object</param>
        /// <param name="siteUrl">Targeted site URL</param>
        /// <returns>Result</returns>
        public Result UpdateTimesheet(Timesheet objWorkItems, string siteUrl)
        {
            Result res = new Result();
            try
            {
                res = CRUDOperations.UpdateListItem<Timesheet>(Lists.Lists.Timesheet, objWorkItems);
                res.StatusCode = StatusCode.Success; res.Message = Messages.MsgSuccessUpdate;
                return res;
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                res.Message = Messages.MsgSomethingWentWrong; res.StatusCode = StatusCode.Error;
                return res;
            }
        }

        public Result UpdateTimesheetSyncStatus(List<SyncStatus> objSyncStatus, string siteUrl)
        {
            Result res = new Result();
            try
            {
                int recordsUpdatedCounter = 0;
                foreach (var _recordIDObj in objSyncStatus)
                {
                    Result updateResult = new Result();
                    Timesheet objTimesheetItem = new Timesheet();
                    objTimesheetItem.ID = _recordIDObj.ID;
                    objTimesheetItem.IsSynced = _recordIDObj.IsSynced;
                    updateResult = UpdateTimesheet(objTimesheetItem, siteUrl);
                    if (updateResult.StatusCode.Equals(1))
                        recordsUpdatedCounter++;
                }
                res.StatusCode = StatusCode.Success;
                res.Message = recordsUpdatedCounter + " " + Messages.MsgSuccessRecordsUpdate;
                return res;
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                res.Message = Messages.MsgSomethingWentWrong;
                res.StatusCode = StatusCode.Error;
                return res;
            }
        }

        public Result UpdateTimesheetSyncStatusByRecordID(List<SyncStatusByRecordID> objSyncStatus, string siteUrl)
        {
            Result res = new Result();
            try
            {
                int recordsUpdatedCounter = 0;
                foreach (var _recordIDObj in objSyncStatus)
                {
                    List<TimesheetWithWorkItems> objWorkItemList = GetTimesheetByRecordID(_recordIDObj.RecordID, siteUrl);
                    foreach (var timesheetRecord in objWorkItemList)
                    {
                        Timesheet objTimesheetItem = new Timesheet();
                        Result updateResult = new Result();
                        objTimesheetItem.ID = timesheetRecord.ID;
                        objTimesheetItem.IsSynced = _recordIDObj.IsSynced;
                        updateResult = UpdateTimesheet(objTimesheetItem, siteUrl);
                        if (updateResult.StatusCode.Equals(1))
                            recordsUpdatedCounter++;
                    }
                }
                res.StatusCode = StatusCode.Success;
                res.Message = recordsUpdatedCounter + " " + Messages.MsgSuccessRecordsUpdate;
                return res;
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                res.Message = Messages.MsgSomethingWentWrong;
                res.StatusCode = StatusCode.Error;
                return res;
            }
        }
    }
}
