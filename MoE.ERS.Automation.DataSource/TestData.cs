using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoE.ERS.Automation.Entities;
using GenFu;
using System.Linq.Expressions;
    
namespace MoE.ERS.Automation.DataSource
{
    public class TestData<Entity> where Entity : EntityBase, new()
    {
        public Entity GetSingleData()
        {
            return A.New<Entity>();
        }
        public List<Entity> GetMultipleData()
        {
            return A.ListOf<Entity>();          
        }

        public Entity SetEntityField<FTYPE>(Expression<Func<Entity, FTYPE>> fieldExpression, FTYPE fieldValue)
        {
            A.Configure<Entity>()               
                .Fill(fieldExpression,fieldValue);
            return A.New<Entity>();
        } 
       
        public List<Entity> SetEntityFields<FTYPE>(Expression<Func<Entity, FTYPE>> fieldExpression,FTYPE[] fieldValues)
        {
            A.Configure<Entity>()
                .Fill(fieldExpression)
                .WithRandom(fieldValues);
            return A.ListOf<Entity>();
        }        
    }
}
