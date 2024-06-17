using ResourceRequestService.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceRequestService.Helpers
{
    public class Core
    {
        private readonly RepositoryDbContext _repositorycontext;
        private readonly EDMDbContext _edmdbcontext;
        public Core(RepositoryDbContext repositorycontext, EDMDbContext edmrepositorycontext)
        {
            _repositorycontext = repositorycontext;
            _edmdbcontext = edmrepositorycontext;
        }
        public Response USp_Onboard_List_Project(string CuIden, string Group)
        {
            Response response = new();
            try
            {
                if (!(_repositorycontext.ExIpcustomerProjects.Where(x => x.CuIden.ToString() == CuIden && x.Group == Group).Any()))
                {
                    var data = new { Proj_Id = 0, Proj_Name = "N/A" };
                    response.Data = data;
                }
                else
                {
                    var data = (from c in _repositorycontext.ExIpcustomerProjects
                                where c.CuIden.ToString() == CuIden && c.Group == Group
                                select new
                                {
                                    Proj_Id = c.ProjId,
                                    c.Group
                                }).Distinct().ToList();
                    response.Data = data;
                }
                response.Status = true;
                response.Message = "Success";
                response.Error = "";
                return response;
            }
            catch (System.Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                response.Error = ex.ToString();
                return response;
            }
        }

        public string uFn_LoginCheck(string userLognID)
        {
            //throw new NotImplementedException();
            string loginType = string.Empty;
            //var customerAdmin = (from a in _repositorycontext.ExCustomerAdmins
            //                     where a.IplanCustid == 809 && a.IpLanPersonlOgin == userLognID
            //                     && a.Status == "A" && a.IsAdmin == "N"
            //                     select new
            //                     {
            //                         a.IplanCustid

            //                     }
            //    ).ToList();
            //string[] role = { "DM", "VP", "AVP" };
            //string[] dept = { "PRTRN", "MATKM" };
            //string[] dept1 = { "CMPL", "MACOM" };
            //if (customerAdmin.Count > 0)
            //{
            //    if ((from a in _repositorycontext.ExAccessMasters where a.Enddate == null && a.Role == "RM" && a.PeLogn == userLognID select new { a.PeLogn }).ToList().Count > 0)
            //    {
            //        loginType = "RM";

            //    }
            //    else if ((from a in _repositorycontext.ExResourceassignmentstatuses where a.Enddate == null && a.PeLogn == userLognID && role.Contains(a.Role) select new { a.Role }).ToList().Count > 0)
            //    {
            //        loginType = "DM";

            //    }
            //    else if ((from a in _repositorycontext.ExAccessMasters where a.Enddate == null && a.Role == "PMO" && a.PeLogn == userLognID select new { a.PeLogn }).ToList().Count > 0)
            //    {
            //        loginType = "PMO";

            //    }
            //    else if ((from a in _repositorycontext.ExResourceassignmentstatuses where a.Enddate == null && a.PeLogn == userLognID && a.Role == "SUPR" select new { a.Role }).ToList().Count > 0)
            //    {
            //        loginType = "SUPR";
            //    }

            //}
            //else
            {
                if (((from a in _edmdbcontext.ExCustomerAdmins where a.IplanCustid.ToString() == "830" && a.IpLanPersonlOgin == userLognID && a.Status == "A" && a.IsAdmin == "Y" select new { a.IplanCustid }).ToList().Count > 0) )
                {
                    loginType = "ADMIN";

                }
                else if ((from a in _edmdbcontext.IpPeople join b in _edmdbcontext.ExIpelements on a.PeDept equals b.ElCode where a.PeLogn == userLognID && b.RoleInd.ToLower() == "yes" && b.ElCode.ToLower() == "clead" select new { a.PeLogn }).ToList().Count > 0)
                {
                    loginType = "CDH";
                }
                else if ((from a in _repositorycontext.ExClientPlOwners where a.Enddate == null && a.PeLogn == userLognID select new { a.PeLogn }).ToList().Count > 0)
                {
                    loginType = "PL";
                }
                else if ((from a in _repositorycontext.ExAccessMasters where a.Enddate == null && a.Role.ToLower() == "pmo" && a.PeLogn == userLognID select new { a.PeLogn }).ToList().Count > 0)
                {
                    loginType = "PMO";
                } 
                else if ((from a in _repositorycontext.ExIpcustomerOthers where a.PeLogn == userLognID && a.Role.ToLower() == "emgr" && a.Enddate == null select new { a.PeLogn }).ToList().Count > 0)
                {
                    loginType = "EMGR";
                }  
                else if ((from a in _repositorycontext.ExResourceassignmentstatuses where a.Enddate == null && a.PeLogn == userLognID && a.Role.ToLower()=="dm" select new { a.Role }).ToList().Count > 0)
                {
                    loginType = "DM";
                }
                else if ((from a in _repositorycontext.ExAccessMasters where a.Enddate == null && a.Role.ToLower() == "rm" && a.PeLogn == userLognID select new { a.PeLogn }).ToList().Count > 0)
                {
                    loginType = "RM";

                }
                else
                {
                    loginType = "NONE";
                }


                //else if ((from a in _repositorycontext.ExResourceassignmentstatuses where a.Enddate == null && a.PeLogn == userLognID && a.Role == "SUPR" select new { a.Role }).ToList().Count > 0)
                //{
                //    loginType = "SUPR";
                //}
                //else if ((from a in _repositorycontext.IpPeople where a.PeLogn == userLognID && a.PeQuit == null && dept.Contains(a.PeDept) select new { a.PeLogn }).ToList().Count > 0)
                //{
                //    loginType = "TDA";

                //}
                //else if ((from a in _repositorycontext.ExCustomerAdmins where a.IplanCustomername == "Trajan OEU" && a.IpLanPersonlOgin == userLognID && a.Status == "A" && a.IsAdmin == "Y" select new { a.IplanCustid }).ToList().Count > 0)
                //{
                //    loginType = "Trajan";

                //}
                //else if ((from a in _repositorycontext.IpPeople where a.PeLogn == userLognID && a.PeDept == "IT1" && a.PeQuit == null select new { a.PeDept }).ToList().Count > 0)
                //{
                //    loginType = "ADMIN";

                //}
                //else if ((from a in _repositorycontext.IpPeople where a.PeLogn == userLognID && a.PeDept == "ADMN" && a.PeQuit == null select new { a.PeLogn }).ToList().Count > 0)
                //{
                //    loginType = "ADMN";

                //}
                // else if ((from a in _repositorycontext.IpPeople where a.PeLogn == userLognID && a.PeDept == "LEGL" && a.PeQuit == null select new { a.PeLogn }).ToList().Count > 0)
                //{
                //    loginType = "LEGL";
                //}
                //else if ((from a in _repositorycontext.IpPeople where a.PeLogn == userLognID && dept1.Contains(a.PeDept) && a.PeQuit == null select new { a.PeLogn }).ToList().Count > 0)
                //{
                //    loginType = "ADMIN";
                //}
                //else if ((from a in _repositorycontext.IpPeople where a.PeLogn == userLognID && a.PeDept == "ISM" && a.PeQuit == null select new { a.PeLogn }).ToList().Count > 0)
                //{
                //    loginType = "ISM";
                //}
                //else if ((from a in _repositorycontext.IpPeople where a.PeLogn == userLognID && a.PeDept == "HR1" && a.PeQuit == null select new { a.PeLogn }).ToList().Count > 0)
                //{
                //    loginType = "HR";
                //}
                //else if ((from a in _repositorycontext.ExIpcustomerOthers where a.PeLogn == userLognID && a.Role == "ACCMG" && a.Enddate == null select new { a.PeLogn }).ToList().Count > 0)
                //{
                //    loginType = "ACCMG";
                //}
                //else if ((from a in _repositorycontext.ExAccessMasters where a.Role == "PMO" && a.Enddate == null && a.Status == "A" && a.PeLogn == userLognID select new { a.PeLogn }).ToList().Count > 0)
                //{
                //    loginType = "PMO";

                //}

            }
            return string.IsNullOrEmpty(loginType) ? "" : loginType;

        }

        public string getdepartment(string userLognID)
        {
            //throw new NotImplementedException();
            string loginType = string.Empty;
            var persondept = (from a in _edmdbcontext.IpPeople
                                 where a.PeLogn==userLognID 
                                 select new
                                 {
                                     a.PeDept

                                 }
                ).ToList();
        
           
            return string.IsNullOrEmpty(persondept[0].PeDept.ToString()) ? "" : persondept[0].PeDept.ToString();

        }
        public int uFn_Check_PLOwner(ResourceRequest model)
        {
            // throw new NotImplementedException();
            int PL = 0;
            int PMO = 0;
            int flag = 0;
            PL = (from a in _repositorycontext.ExClientPlOwners where a.Enddate == null && a.PeLogn == model.UserLognID select new { a.PeLogn }).ToList().Count();
            PMO = (from a in _repositorycontext.ExAccessMasters where a.Enddate == null && a.PeLogn == model.UserLognID && a.Status == "A" && a.Role == "PMO" select new { a.Role }).ToList().Count();
            if (PL == 1 || PMO == 1)
            {
                flag = 1;

            }
            if (model.LognType == "Admin")
            {
                flag = 0;
            }
            return flag;
        }
        public int UFn_GetClientGroupWithLOB(string login)
        {
            Response response = new();
            try
            {
                var result = (from o in _repositorycontext.MasterAbbrevations
                              join e in _repositorycontext.ExClientPlOwners on o.Lob equals e.ServiceLine into oe
                              from e in oe.DefaultIfEmpty()
                              where e.Enddate == null && e.PeLogn == login
                              select new
                              {
                                  LOB = o.Lob,
                                  GRP = o.Code
                              }).Distinct().ToList();

                var result2 = (from o in _repositorycontext.MasterAbbrevations
                               join e in _repositorycontext.ExAccessMasters on o.Lob equals e.ServiceLine into oe
                               from e in oe.DefaultIfEmpty()
                               where e.Enddate == null && e.PeLogn == login && e.Role == "PMO"
                               select new
                               {
                                   LOB = o.Lob,
                                   GRP = o.Code
                               }).Distinct().ToList();

                result.AddRange(result2);

                response.Data = result;
                response.Status = true;
                response.Message = "Success";
                response.Error = "";
                return result.Count;
            }
            catch (System.Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                response.Error = ex.ToString();
                return 0;
            }
        }
        public Response uSp_Onboard_List_ClientGroup(int cuIden)
        {
            Response response = new();
            //throw new NotImplementedException();
            try
            {
                var IpElements = (from a in _edmdbcontext.IpElements select a).ToList();
                var ExIpcustomerOthers = (from a in _repositorycontext.ExIpcustomerOthers  select a).ToList();
                var MasterAbbrevations = (from a in _repositorycontext.MasterAbbrevations  select a).ToList();


                string[] caRoleG = { "CHEAD", "EMGR", "ACCMG" };
                string[] elCodeG = { "QNTSR", "PTQNT" };
                string[] clientGroupG = { "PT" };
                var dataG = (from El in IpElements
                             join Ex in ExIpcustomerOthers on El.ElCode equals Ex.Clientgroup
                             where Ex.CuIden == cuIden
                             && caRoleG.Contains(Ex.Role)
                             && !elCodeG.Contains(El.ElCode)
                             && Ex.Enddate == null
                             && !clientGroupG.Contains(Ex.Clientgroup)
                             orderby El.ElName
                             select new
                             {
                                 ClientGroup = El.ElName.ToUpper(),
                                 Group = El.ElCode

                             }).Distinct().ToList();
                if (cuIden == 85)
                {
                    string[] caCode = { "DELIV", "SUPP", "PTBAU", "SSSER" };
                    string[] elCode = { "DEM", "FIBD", "BD", "EQUIT", "FIC", "FMS", "LRC", "QNTS", "QNTSR", "PTQNT" };
                    var data = (from El in IpElements
                                where caCode.Contains(El.CaCode)
                                && !elCode.Contains(El.ElCode)
                                orderby El.ElName
                                select new
                                {
                                    ClientGroup = El.ElName.ToUpper(),
                                    Group = El.ElCode

                                }).Distinct().ToList();
                    response.Data = data;

                }
                else if (cuIden == 206 || cuIden == 207)
                {

                    string[] caRole = { "CHEAD", "EMGR", "ACCMG" };
                    string[] elCode = { "QNTSR", "PTQNT" };
                    var data = (from El in IpElements
                                join Ex in ExIpcustomerOthers on El.ElCode equals Ex.Clientgroup
                                where Ex.CuIden == cuIden
                                && caRole.Contains(Ex.Role)
                                && !elCode.Contains(El.ElCode)
                                && Ex.Enddate == null
                                orderby El.ElName
                                select new
                                {
                                    ClientGroup = El.ElName.ToUpper(),
                                    Group = El.ElCode

                                }).Distinct().ToList();
                    response.Data = data;

                }
                else if (dataG.Count == 0)
                {
                    var dataList = (
                        from a in _repositorycontext.ExClientServicelines
                        where a.CuIden == cuIden && a.Enddate == null && a.Status == "A"
                        select new
                        {
                            service_line = a.ServiceLine
                        }
                        ).ToList();
                    string[] serviceLine = new string[dataList.Count + 1];
                    for (int i = 0; i < dataList.Count; i++)
                    {
                        serviceLine[i] = dataList[i].service_line;
                    }

                    var data = (from a in  MasterAbbrevations
                                join b in IpElements on a.Code equals b.ElCode into IP1
                                from b in IP1.DefaultIfEmpty()
                                where serviceLine.Contains(a.Lob)
                                select new
                                {
                                    Group = a.Code,
                                    ClientGroup = b!=null ? b.ElName.ToUpper() :""

                                }).ToList();
                    response.Data = data; 

                }
                else if (cuIden != 85 || cuIden != 206 || cuIden != 207)
                {
                    var dataList = (
                        from a in _repositorycontext.ExClientServicelines
                        where a.CuIden == cuIden && a.Enddate == null && a.Status == "A"
                        select new
                        {
                            service_line = a.ServiceLine
                        }
                        ).ToList();
                    string[] serviceLine = new string[dataList.Count + 1];
                    for (int i = 0; i < dataList.Count; i++)
                    {
                        serviceLine[i] = dataList[i].service_line;
                    }
                    var data = (from a in MasterAbbrevations
                                    //join b in IpElements on a.Code equals b.ElCode into IP1
                                    //from b in IP1.DefaultIfEmpty()
                                join b in IpElements on new
                                { User = a != null ? a.Code : "" }
                  equals new { User = b != null ? b.ElCode : "" }

                              into cp1
                                from b in cp1.DefaultIfEmpty()
                                where serviceLine.Contains(a.Lob)
                                 //&& b.ElName != null
                                //orderby b.ElName
                                select new
                                {
                                    Group11 = a.Code,
                                    ClientGroup111= b!=null? b.ElName.ToUpper() : "NA"

                                }).ToList();

                    //var data1 = data.ToList().Where(x => x.ClientGroup111 != "NA");
                    response.Data = data;

                }

                response.Status = true;
                response.Message = "Success";
                response.Error = "";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                response.Error = ex.ToString();
                response.Data = "";
                return response;

            }
            // return null;
        }
        public Response uSp_RR_ListDM(ClientModel model)
        {
            //throw new NotImplementedException();
            Response response = new();
            try
            {
                var ExIpcustomerOthers = (from a in _repositorycontext.ExIpcustomerOthers select a).ToList();
                var ExIpcustomerRoles = (from a in _repositorycontext.ExIpcustomerRoles select a).ToList();
                var IpPeople = (from a in _edmdbcontext.IpPeople where a.PeQuit == null select a).ToList();

                var data1 = (from Ex in ExIpcustomerOthers
                             join Pe in IpPeople on Ex.PeLogn equals Pe.PeLogn
                             where Ex.Role == "DM" && Ex.Enddate == null && Ex.CuIden == model.CU_IDEN
                             && Pe.PeQuit == null
                             select new
                             {
                                 Name = Pe.PeName.ToUpper(),
                                 Logn = Ex.PeLogn,
                                 Desg = Ex.Role == "ACCMG" ? "AC" : Ex.Role == "VP" ? "VP" : Ex.Role == "DM" ? "VP" : Ex.Role == "CHEAD" ? "VP" : Ex.Role == "EMGR" ? "VP" : Ex.Role,

                             }
                           ).Distinct().ToList();
                string[] LognList = new string[data1.Count + 1];
                for (int i = 0; i < data1.Count; i++)
                {
                    LognList[i] = data1[i].Logn;
                }


                var data2 = (from Ex in ExIpcustomerRoles
                             join Pe in IpPeople on Ex.PeLogn equals Pe.PeLogn
                             where Ex.Role == "DM" && Ex.RoleEnddate == null && Ex.CuIden == model.CU_IDEN
                             && Pe.PeQuit == null && LognList.Contains(Pe.PeLogn)
                             select new
                             {
                                 Name = Pe.PeName.ToUpper(),
                                 Logn = Ex.PeLogn,
                                 Desg = Ex.Role == "ACCMG" ? "AC" : Ex.Role == "VP" ? "VP" : Ex.Role == "DM" ? "VP" : Ex.Role,

                             }
                           ).Distinct().ToList();
                var unionData = data1.Union(data2);
                string[] roleList = { "ACCMG", "VP", "DM", "SUPR" };
                string[] desgList = { "VP", "SUPR" };
                var pelognData = (from Ex in _repositorycontext.ExIpcustomerRoles
                                  where roleList.Contains(Ex.Role) && Ex.RoleEnddate == null && Ex.CuIden == model.CU_IDEN
                                  select new
                                  {
                                      Pe_Logn = Ex.PeLogn

                                  }).ToList();
                string[] peLognList = new string[pelognData.Count + 1];
                for (int i = 0; i < pelognData.Count; i++)
                {
                    peLognList[i] = pelognData[i].Pe_Logn;
                }
                List<RoleListDM> roleListModel = new List<RoleListDM>();
                foreach (var datamodel in unionData)
                {
                    RoleListDM obj = new RoleListDM();
                    obj.Desg = datamodel.Desg;
                    obj.Logn = datamodel.Logn;
                    obj.Name = datamodel.Name;
                    roleListModel.Add(obj);

                }
                roleListModel = roleListModel.Where(w => !desgList.Contains(w.Desg) && peLognList.Contains(w.Logn)).Select(w => { w.Desg = "VP"; return w; }).ToList();
                string[] Dlist = { "DM", "VP" };
                if (model.Type.ToUpper() == "D")
                {
                    roleListModel = roleListModel.Where(w => Dlist.Contains(w.Desg)).OrderBy(p => p.Desg).OrderBy(e => e.Name).ToList();

                }
                else if (model.Type.ToUpper() == "S")
                {
                    roleListModel = roleListModel.Where(w => w.Desg == "SUPR").OrderBy(p => p.Desg).OrderBy(e => e.Name).ToList();

                }

                // unionData = unionData.Where(w => w.Name == "Tom").Select(w => { w.Desg = "a"; return w}).ToList();

                //var Valid = unionData.Where(c => !desgList.Contains(c.Desg) && peLognList.Contains(c.Logn)).ToList().ForEach(i => i.Desg = "VP");
                //var inValid= unionData.Where(c => desgList.Contains(c.Desg) && !peLognList.Contains(c.Logn)).ToList();                
                //ValidCustomers.ForEach(c => c.Desg = "VP");

                response.Status = true;
                response.Message = "Success";
                response.Error = "";
                response.Data = roleListModel;
                return response;

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                response.Error = ex.ToString();
                response.Data = "";
                return response;

            }
        }

        public Response uSp_Onboard_ListReason(int CuIden)
        {
            Response response = new();
            try
            {
                string[] types = new[] { "P", "B" };
                string[] levels = new[] { "BP", "BR", "NBST6" };
                string[] onboardstatus = new[] { "NPNJ", "NPIT" };
                var result = _repositorycontext.ExStatusdescs
                                .Where(x => types.Contains(x.Type) && x.OnOff == 0 && x.Status == "A" && !levels.Contains(x.Level))
                                .Select(s => new { s.StatusLevelId, s.StatusIndicator, s.Level, s.StatusShortDesc })
                                .OrderBy(o => o.StatusLevelId).ToList();
                if (CuIden != 85 && CuIden != 206 && CuIden != 207)
                {
                    result.RemoveAll(r => onboardstatus.Contains(r.Level));
                }
                response.Data = result;
                response.Status = true;
                response.Message = "Success";
                response.Error = "";
                return response;
            }
            catch (System.Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                response.Error = ex.ToString();
                return response;
            }
        }

        public Response USP_RR_CountryList()
        {
            Response response = new();
            try
            {
                int[] locations = new int[] { 0, 1, 2, 3, 4, 5, 6, 8, 10, 11, 12, 13, 16, 17, 18, 23, 24, 25, 26 };
                var data = (from l in _edmdbcontext.IpLocations
                            where !locations.Contains(l.IpLocn)
                            select new
                            {
                                LID = l.IpLocn,
                                Location = l.LnName.ToUpper(),
                            }).OrderBy(o => o.Location).ToList();

                response.Data = data;
                response.Status = true;
                response.Message = "Success";
                response.Error = "";
                return response;
            }
            catch (System.Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                response.Error = ex.ToString();
                return response;
            }
        }

        public Response USP_GetApproverList(int CuIden)
        {
            Response response = new();
            try
            {
                //var data = (from pe in _repositorycontext.IpPeople
                //            join ex in _repositorycontext.ExIpcustomerOthers on pe.PeLogn equals ex.PeLogn
                //            where ex.CuIden == CuIden && pe.PeQuit == null && ex.Enddate == null && ex.Role == "EMGR"
                //            group pe by ex into ep
                //            select new
                //            {
                //                Approver = string.Join(",", ep.Select(i => i.PeName)),
                //            }).Distinct().ToList();
                var result = (from pe in _edmdbcontext.IpPeople
                              join ex in _repositorycontext.ExIpcustomerOthers on pe.PeLogn equals ex.PeLogn
                              where ex.CuIden == CuIden && pe.PeQuit == null && ex.Enddate == null && ex.Role == "EMGR"
                              select new
                              {
                                  Approver = pe.PeName,
                              }).Distinct().ToList();

                var data = String.Join(", ", result.Select(p => p.Approver));

                response.Data = data;
                response.Status = true;
                response.Message = "Success";
                response.Error = "";
                return response;
            }
            catch (System.Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                response.Error = ex.ToString();
                return response;
            }
        }
    }
}
