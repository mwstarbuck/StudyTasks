using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ninject;
using StudyTasks.DAL;
using OfficeOpenXml;
using System.IO;
using StudyTasks.Models;
using StudyTasks;
using Microsoft.Extensions.Configuration;

namespace DatabaseUtiliies
{
    class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            StandardKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetCallingAssembly());

            InsertVocabulary(kernel);


        }

        static void InsertVocabulary(StandardKernel kernel)
        {
            string filePath = @"D:\Data\Level2_Words.xlsx";
            FileInfo file = new FileInfo(filePath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorksheet sheet = excelPackage.Workbook.Worksheets[0];
                int startingRow = 2;
                List<Vocabulary> words = new List<Vocabulary>();
                for (int i = startingRow; i <= 296; i++)
                {
                    var word = new Vocabulary();
                    if (word.Id == Guid.Empty)
                    {
                        word.Id = Guid.NewGuid();
                    }
                    if (sheet.Cells[i, 1].Value != null)
                    {
                        word.Word = sheet.Cells[i, 1].Value.ToString().Trim();
                    }
                    if (sheet.Cells[i, 2].Value != null)
                    {
                        word.GradeLevel = Convert.ToInt32(sheet.Cells[i, 2].Value);
                    }
                    words.Add(word);
                }

                var provider = kernel.Get<IProvideStudyTasks>();
                
                provider.InsertVocabulary(words);
                
            }
            

        }
    }
}
