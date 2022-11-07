using CoreDL.Entity;
using Entity;
using MISA.VMHUNG.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDL.Interface
{
    public interface IReportSettingDL : IBaseDL<template_setting>
    {
        public Task<bool> saveTemplate(template_setting template);
    }
}
