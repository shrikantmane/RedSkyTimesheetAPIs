using ESPL.RedSkyTimeSheet.BL.Models;
using ESPL.RedSkyTimeSheet.BL.Operations.Common;
using ESPL.RedSkyTimeSheet.BL.Operations.Masters;
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
    public class WorkItemsOperations
    {
        /// <summary>
        /// Get All Timesheets
        /// </summary>
        /// <param name="id"></param>
        /// <param name="siteUrl"></param>
        /// <returns></returns>
        public List<WorkItems> GetWorkItems(string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.WorkItems, true),
                                                    string.Format(Lists.RestFilters.topItems, GetTop.Default));

                return CRUDOperations.GetListByRestURL<WorkItems>(RestUrl);
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
        public List<WorkItems> GetWorkItemsByID(string id, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.WorkItems, true),
                                                    string.Format(RestFilters.ByID, id), string.Format(Lists.RestFilters.topItems, GetTop.Default));

                return CRUDOperations.GetListByRestURL<WorkItems>(RestUrl).ToList();
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
        public List<WorkItems> GetWorkItemsByRecordID(string id, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.WorkItems, true),
                                                    string.Format(RestFilters.ByRecordID, id), string.Format(Lists.RestFilters.topItems, GetTop.Default));

                return CRUDOperations.GetListByRestURL<WorkItems>(RestUrl).ToList();
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        /// <summary>
        /// Get Detailed Timesheets by Master Timesheet ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="siteUrl"></param>
        /// <returns></returns>
        public List<WorkItems> GetWorkItemsByTimesheetID(string id, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.WorkItems, true),
                                                    string.Format(RestFilters.ByTimesheetID, id), string.Format(Lists.RestFilters.topItems, GetTop.Default));

                return CRUDOperations.GetListByRestURL<WorkItems>(RestUrl).ToList();
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
        public List<WorkItems> GetWorkItemsByStatus(string status, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.WorkItems, true),
                                                    string.Format(RestFilters.ByStatus, status), string.Format(Lists.RestFilters.topItems, GetTop.Default));

                return CRUDOperations.GetListByRestURL<WorkItems>(RestUrl).ToList();
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
        public List<WorkItems> GetWorkItemsBySyncStatus(int syncStatus, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.WorkItems, true),
                                                    string.Format(RestFilters.BySyncStatus, syncStatus), string.Format(Lists.RestFilters.topItems, GetTop.Default));

                return CRUDOperations.GetListByRestURL<WorkItems>(RestUrl).ToList();
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
        public List<WorkItems> GetWorkItemsByStatusAndTimesheetID(WorkItemStatusAndTimesheetID objStatusTimesheetID, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.WorkItems, true),
                                                    string.Format(RestFilters.ByStatusTimesheetID, objStatusTimesheetID.TimesheetID.Value, objStatusTimesheetID.Status), string.Format(Lists.RestFilters.topItems, GetTop.Default));

                return CRUDOperations.GetListByRestURL<WorkItems>(RestUrl).ToList();
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
        public List<WorkItems> GetWorkItemsByDateEmployeeProjectPhaseTask(WorkItemsByDateEmployeeProejctPhaseTask objWorkItem, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.WorkItems, true),
                                                    string.Format(RestFilters.WorkItemsByDate_Employee_Proejct_Phase_Task, objWorkItem.Date.ToString("yyyy-MM-ddTHH:mm:ssZ"), objWorkItem.Employee.ID, objWorkItem.Project.ID, objWorkItem.Phase.ID, objWorkItem.Task.ID), string.Format(Lists.RestFilters.topItems, GetTop.Default));

                return CRUDOperations.GetListByRestURL<WorkItems>(RestUrl).ToList();
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        /// <summary>
        /// Approve WorkItems by ID
        /// </summary>
        /// <param name="">  </param>
        /// <param name="siteUrl"></param>
        /// <returns></returns>
        public Result ApproveWorkItemsByID(ApproverTimesheetViewModel approverEmployeeTimesheet, string siteUrl)
        {
            Result res = new Result();
            try
            {
                WorkItemsOperations WorkItemOperations = new WorkItemsOperations();
                List<WorkItems> _workitemList = WorkItemOperations.GetWorkItemsByID(approverEmployeeTimesheet.ID, siteUrl);
                //Approve Work Items
                res = UpdateWorkItemsStatus(approverEmployeeTimesheet, siteUrl, _workitemList, TimesheetStatus.Approved);

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
        /// Approve WorkItems by Record ID
        /// </summary>
        /// <param name="">  </param>
        /// <param name="siteUrl"></param>
        /// <returns></returns>
        public Result ApproveWorkItemsByRecordID(ApproverTimesheetViewModel approverEmployeeTimesheet, string siteUrl)
        {
            Result res = new Result();
            try
            {
                WorkItemsOperations WorkItemOperations = new WorkItemsOperations();
                List<WorkItems> _workitemList = WorkItemOperations.GetWorkItemsByRecordID(approverEmployeeTimesheet.ID, siteUrl);
                res = UpdateWorkItemsStatus(approverEmployeeTimesheet, siteUrl, _workitemList, TimesheetStatus.Approved);
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
        /// Reject Timesheets by ID
        /// </summary>
        /// <param name="siteUrl"></param>
        /// <returns></returns>
        public Result RejectWorkItems(ApproverTimesheetViewModel approverEmployeeTimesheet, string siteUrl)
        {
            Result res = new Result();
            try
            {
                WorkItemsOperations WorkItemOperations = new WorkItemsOperations();
                List<WorkItems> _workitemList = WorkItemOperations.GetWorkItemsByID(approverEmployeeTimesheet.ID, siteUrl);
                res = UpdateWorkItemsStatus(approverEmployeeTimesheet, siteUrl, _workitemList, TimesheetStatus.Rejected);
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
        /// Reject Timesheets by Record ID
        /// </summary>
        /// <param name=""></param>
        /// <param name="siteUrl"></param>
        /// <returns></returns>
        public Result RejectWorkItemsByRecordID(ApproverTimesheetViewModel approverEmployeeTimesheet, string siteUrl)
        {
            Result res = new Result();
            try
            {
                WorkItemsOperations WorkItemOperations = new WorkItemsOperations();
                List<WorkItems> _workitemList = WorkItemOperations.GetWorkItemsByRecordID(approverEmployeeTimesheet.ID, siteUrl);
                res = UpdateWorkItemsStatus(approverEmployeeTimesheet, siteUrl, _workitemList, TimesheetStatus.Rejected);
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
        /// Update Employee Timesheet status
        /// </summary>
        /// <param name="approverEmployeeTimesheet"></param>
        /// <param name="siteUrl"></param>
        /// <param name="_employeeTimesheetID"></param>
        private static Result UpdateWorkItemsStatus(ApproverTimesheetViewModel approverEmployeeTimesheet, string siteUrl, List<WorkItems> WorkItemList, string _status)
        {
            WorkItemsOperations WorkItemOperations = new WorkItemsOperations();
            Result res = new Result();

            ApprovalHistoryOperations historyOps = new ApprovalHistoryOperations();
            foreach (var item in WorkItemList)
            {
                WorkItems newItem = new WorkItems();
                newItem.ID = item.ID;
                newItem.ApprovalComments = approverEmployeeTimesheet.ApproverRemarks;
                newItem.Staus = _status;
                newItem.ApprovalOn = approverEmployeeTimesheet.ApprovedOn;
                newItem.Approver = approverEmployeeTimesheet.Approver;
                res = WorkItemOperations.UpdateWorkItems(newItem, siteUrl);

                if (res.StatusCode.Equals(1))
                {
                    //Add To Approval History List
                    ApprovalHistory newApprovalHistory = new ApprovalHistory();
                    newApprovalHistory.Approver = approverEmployeeTimesheet.Approver;
                    newApprovalHistory._ApprovalComments = approverEmployeeTimesheet.ApproverRemarks;
                    newApprovalHistory._ApprovalOn = approverEmployeeTimesheet.ApprovedOn;
                    newApprovalHistory.Status = _status;
                    newApprovalHistory._ChildID = new TitleLookup { ID = newItem.ID };
                    res = historyOps.AddApprovalHistory(newApprovalHistory, siteUrl);
                }
            }
            return res;
        }

        /// <summary>
        /// Update Work Items into List
        /// </summary>
        /// <param name="objTimesheets">Timesheet object</param>
        /// <param name="siteUrl">Targeted site URL</param>
        /// <returns>Result</returns>
        public Result UpdateWorkItems(WorkItems objWorkItems, string siteUrl)
        {
            Result res = new Result();
            try
            {
                res = CRUDOperations.UpdateListItem<WorkItems>(Lists.Lists.WorkItems, objWorkItems);
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

        public Result UpdateWorkItemRecordId(List<SyncRecordID> objRecordIDs, string siteUrl)
        {
            Result res = new Result();
            try
            {

                int recordsUpdatedCounter = 0;
                foreach (var _recordIDObj in objRecordIDs)
                {
                    Result updateResult = new Result();
                    WorkItems objWorkItem = new WorkItems();
                    objWorkItem.ID = _recordIDObj.ID;
                    objWorkItem.RecordID = _recordIDObj.RecordID;
                    updateResult = UpdateWorkItems(objWorkItem, siteUrl);
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

        public Result UpdateWorkItemSyncStatus(List<SyncStatus> objSyncStatus, string siteUrl)
        {
            Result res = new Result();
            try
            {
                int recordsUpdatedCounter = 0;
                foreach (var _recordIDObj in objSyncStatus)
                {
                    Result updateResult = new Result();
                    WorkItems objWorkItem = new WorkItems();
                    objWorkItem.ID = _recordIDObj.ID;
                    objWorkItem.IsSynced = _recordIDObj.IsSynced;
                    updateResult = UpdateWorkItems(objWorkItem, siteUrl);
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

        public Result UpdateWorkItemSyncStatusByRecordID(List<SyncStatusByRecordID> objSyncStatus, string siteUrl)
        {
            Result res = new Result();
            try
            {
                int recordsUpdatedCounter = 0;
                foreach (var _recordIDObj in objSyncStatus)
                {
                    List<WorkItems> objWorkItemList = GetWorkItemsByRecordID(_recordIDObj.RecordID, siteUrl);
                    foreach (var workItemRecord in objWorkItemList)
                    {
                        WorkItems objWorkItem = new WorkItems();
                        Result updateResult = new Result();
                        objWorkItem.ID = workItemRecord.ID;
                        objWorkItem.IsSynced = _recordIDObj.IsSynced;
                        updateResult = UpdateWorkItems(objWorkItem, siteUrl);
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

        public Result UpdateWorkItemRecordIDUniquely(WorkItemsByDateEmployeeProejctPhaseTask objWorkItems, string siteUrl)
        {
            Result res = new Result();
            try
            {
                List<WorkItems> objWorkItem = GetWorkItemsByDateEmployeeProjectPhaseTask(objWorkItems, siteUrl);
                foreach (WorkItems item in objWorkItem)
                {
                    WorkItems updateItem = new WorkItems();
                    updateItem.ID = item.ID;
                    updateItem.RecordID = objWorkItems.RecordID;
                    res = UpdateWorkItems(updateItem, siteUrl);
                }
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
