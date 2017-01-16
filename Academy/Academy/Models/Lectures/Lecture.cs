using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Contracts;

namespace Academy.Models.Lectures
{
    public class Lecture : ILecture
    {
        private string name;
        private DateTime date;
        private ITrainer trainer;
        private IList<ILectureResouce> resources;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if(value.Length < 5 || value.Length > 30)
                {
                    throw new InvalidOperationException("Lecture's name should be between 5 and 30 symbols long!");
                }
                this.name = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }

        public ITrainer Trainer
        {
            get
            {
                return this.trainer;
            }
            set
            {
                this.trainer = value;
            }
        }

        public IList<ILectureResouce> Resouces
        {
            get
            {
                return this.resources;//new List<ILectureResouce>(this.resources);
            }
            set
            {
                this.resources = value;
            }
        }

        public Lecture(string name, string date, ITrainer trainer)
        {
            this.Name = name;
            this.Date = DateTime.Parse(date);
            this.Trainer = trainer;
            this.Resouces = new List<ILectureResouce>();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("  * Lecture:\n");
            result.AppendFormat($"   - Name: {this.Name}\n");
            result.AppendFormat("   - Date: {0:M\\/dd\\/yyyy hh:mm:ss tt}\n", this.Date);
            result.AppendFormat($"   - Trainer username: {this.Trainer.Username}\n");
            result.AppendFormat($"   - Resources:\n");

            if(this.resources.Count == 0)
            {
                result.AppendFormat("    * There are no resources in this lecture.");
            }
            else
            {
                result.AppendFormat(string.Join("\n", this.Resouces));
            }

            return result.ToString();
        }
    }
}
