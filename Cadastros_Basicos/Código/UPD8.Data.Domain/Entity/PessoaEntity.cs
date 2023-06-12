
namespace UPD8.Data.Domain.Entity
{
    public class PessoaEntity : BaseEntity<long>
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Identidade { get; set; }
    }
}
