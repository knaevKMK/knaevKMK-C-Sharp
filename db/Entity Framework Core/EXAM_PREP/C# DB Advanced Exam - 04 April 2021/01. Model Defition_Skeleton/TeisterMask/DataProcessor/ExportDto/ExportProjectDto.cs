using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
public class ExportProjectDto
    {


        
        public string Name { get; set; }
        public string HasEndDate { get; set; }
        public int TasksCount { get; set; }

        public ExportProjectTaskDto[] Tasks { get; set; }
    }
}
