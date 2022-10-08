using Bieralia.Models;
using System.Collections.Generic;

namespace Bieralia.ViewModels
{
    public class TransactionViewModel
    {
        public TransactionModel Transaction { get; set; }
        public List<TransactionDetailViewModel> TransactionDetailList { get; set; }

    }
}
