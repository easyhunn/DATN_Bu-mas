using CoreBL.Interface;
using CoreDL.Entity;
using CoreDL.Interface;
using Microsoft.AspNetCore.Hosting;
using MISA.VMHUNG.Core.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoreBL
{
    public class ReportSettingBL : BaseBL<template_setting>, IReportSettingBL
    {
        private IReportSettingDL _reportSettingDL;
        public ReportSettingBL(IReportSettingDL reportSettingDL) : base(reportSettingDL)
        {
            this._reportSettingDL = reportSettingDL;
        }
        public async Task<bool> FileUpload(SaveFileParams file)
        {
            var filePaths = new List<string>();
            
            if (file != null && !string.IsNullOrWhiteSpace(file.JsonData))
            {
                var jsonDataObject = JsonSerializer.Deserialize<object>(file.JsonData);
                await using FileStream createStream = File.Create(file.FilePath);
                await JsonSerializer.SerializeAsync(createStream, jsonDataObject);
                // full path to file in temp location
                var filePath = Path.GetTempFileName(); //we are using Temp file name just for the example. Add your own file path.
                filePaths.Add(filePath);

            }
            return true;
        }

        public async Task<bool> saveTemplate(SaveFileParams template)
        {
            var listTemplate = new List<template_setting>();
            listTemplate.Add(template);
            var res = false;
            if (template.mode == 2) {
                res = await _reportSettingDL.Updates<template_setting>(listTemplate);
            }
            else
            {
                res = await _reportSettingDL.Inserts<template_setting>(listTemplate);
            }

            if (res)
            {
                res = await this.FileUpload(template);
            }
            return res;
        }

    }
}
