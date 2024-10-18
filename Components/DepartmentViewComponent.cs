using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using smvn.Models;
using Microsoft.AspNetCore.Mvc;

namespace smvn.Components
{
    [ViewComponent(Name = "DepartmentView")]
    public class DepartmentViewComponent : ViewComponent
    {
        private readonly DataContext _context;
        public DepartmentViewComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listOfDepartment = (from d in _context.Khoas
                                    where (d.IsActive == true)
                                    select d).ToList();
        return await Task.FromResult((IViewComponentResult)View("Default", listOfDepartment));
        }
    }
}