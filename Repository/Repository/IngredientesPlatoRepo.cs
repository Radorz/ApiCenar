using Database.Models;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repository
{
    public class IngredientesPlatoRepo : RepositoryBase<IngredientesPlato, ApiCenarContext>
    {
        public IngredientesPlatoRepo(ApiCenarContext context) : base(context)
        {

        }

    }
}
