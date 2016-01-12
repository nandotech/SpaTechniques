using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaData
{
    public class TrainingProductManager
    {
        public TrainingProductManager()
        {
            ValidationErrors = new List<KeyValuePair<string, string>>();
        }
        public List<KeyValuePair<string,string>> ValidationErrors { get; set; }
        public List<TrainingProduct> Get(TrainingProduct entity)
        {
            ValidationErrors.Clear();
            List<TrainingProduct> ret = new List<TrainingProduct>();
            

            //TODO: Add data access
            ret = CreateMockData();
            if(!string.IsNullOrEmpty(entity.ProductName))
            {
                ret = ret.FindAll(p => p.ProductName.ToLower().StartsWith(entity.ProductName, StringComparison.CurrentCultureIgnoreCase));
            }
            return ret;
        }
        public bool Validate(TrainingProduct entity)
        {
            ValidationErrors.Clear();
            if(!string.IsNullOrEmpty(entity.ProductName))
            {
                if(entity.ProductName.ToLower() == entity.ProductName)
                {
                    ValidationErrors.Add(new KeyValuePair<string, string>("ProductName", "Product Name must not be all lowercase"));
                }
            }

            return (ValidationErrors.Count == 0);

        }
        public bool Insert(TrainingProduct entity)
        {
            bool ret = false;
            ret = Validate(entity);
            if(ret)
            {
                //TODO Create Insert Code
            }
            return ret;
        }
        private List<TrainingProduct> CreateMockData()
        {
            List<TrainingProduct> ret = new List<TrainingProduct>();

            ret.Add(new TrainingProduct()
            {
                ProductId = 1,
                ProductName = "Extending Bootstrap with CSS, Javascript, and jQuery",
                IntroductionDate = Convert.ToDateTime("6/11/2015"),
                Url = "http://bit.ly/lSNzc0i",
                Price = Convert.ToDecimal(29.00)
            });
            ret.Add(new TrainingProduct()
            {
                ProductId = 2,
                ProductName = "Extending Bootstrap with CSS, Javascript, and jQuery",
                IntroductionDate = Convert.ToDateTime("6/11/2015"),
                Url = "http://bit.ly/lSNzc0i",
                Price = Convert.ToDecimal(29.00)
            });
            ret.Add(new TrainingProduct()
            {
                ProductId = 3,
                ProductName = "Extending Bootstrap with CSS, Javascript, and jQuery",
                IntroductionDate = Convert.ToDateTime("6/11/2015"),
                Url = "http://bit.ly/lSNzc0i",
                Price = Convert.ToDecimal(29.00)
            });
            ret.Add(new TrainingProduct()
            {
                ProductId = 4,
                ProductName = "Extending Bootstrap with CSS, Javascript, and jQuery",
                IntroductionDate = Convert.ToDateTime("6/11/2015"),
                Url = "http://bit.ly/lSNzc0i",
                Price = Convert.ToDecimal(29.00)
            });
            return ret;
        }
    }
}
