using System.Threading.Tasks;

namespace SIBSAPIMarket.Client.Model
{
    public delegate Task<ConsentDetails> ConsentRequiredHandler(string bankCode);
}
