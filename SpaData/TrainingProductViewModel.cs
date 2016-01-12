using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaData
{
    public class TrainingProductViewModel
    {
        public TrainingProductViewModel()
        {
            Init();
            Products = new List<TrainingProduct>();
            SearchEntity = new TrainingProduct();
            Entity = new TrainingProduct();
            
        }

        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }
        public List<TrainingProduct> Products { get; set; }
        public string EventCommand { get; set; }
        public TrainingProduct SearchEntity { get; set; }
        public bool IsDetailAreaVisible { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool IsSearchAreaVisible { get; set; }
        public TrainingProduct Entity { get; set; }
        public bool IsValid { get; set; }
        public string Mode { get; set; }
        private void Init()
        {
            ValidationErrors = new List<KeyValuePair<string, string>>();
            EventCommand = "List";
            ListMode();
        }
        private void Get()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            EventCommand = "Search";
            Products = mgr.Get(SearchEntity);
        }
        private void Add()
        {
            IsValid = true;

            Entity = new TrainingProduct();
            Entity.IntroductionDate = DateTime.Now;
            Entity.Url = "http://";
            Entity.Price = 0;

            AddMode();
        }

        public void HandleRequest()
        {
            switch(EventCommand.ToLower())
            {
                case "list":
                case "search":
                    Get();
                    break;
                case "resetsearch":
                    ResetSearch();
                    Get();
                    break;
                case "add":
                    Add();
                    break;
                case "save":
                    Save();
                    if(IsValid)
                    {
                        Get();
                    }
                    break;
                case "cancel":
                    ListMode();
                    Get();
                    break;
                default:
                    break;
            }
        }
        private void ListMode()
        {
            IsListAreaVisible = true;
            IsSearchAreaVisible = true;
            IsDetailAreaVisible = false;
            IsValid = true;
            Mode = "List";
            
        }
        private void AddMode()
        {
            Mode = "Add";
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;
            IsDetailAreaVisible = true;
        }
        private void ResetSearch()
        {
            SearchEntity = new TrainingProduct();
            
        }
        private void Save()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            
                if(Mode == "Add")
                {
                    mgr.Insert(Entity);
                }
                ValidationErrors = mgr.ValidationErrors;
                if(ValidationErrors.Count > 0)
                {
                    IsValid = false;
                }
                if(!IsValid)
                {
                    if(Mode == "Add")
                    {
                        AddMode();
                    }
                }
            
        }
    }
}
