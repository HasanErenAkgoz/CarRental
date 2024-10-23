using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Responses
{
    public class GetAllResponse<T> : BasePageableModel
    {
        private IList<T> _Items;

        public IList<T> Items 
        { 
            get => _Items??= new List<T>();
            set => _Items=value;
        }
    }
}
