using CoreDL.Entity;
using CoreDL.Interface;
using Dapper;
using MISA.VMHUNG.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDL
{
    public class ReportSettingDL : BaseDL<template_setting>, IReportSettingDL
    {
        public async Task<bool> saveTemplate(template_setting template)
        {
            var entity = dbConnection.Execute("insert into Table(val) values (@val)", new { template });
            return true;
        }

    }
}
