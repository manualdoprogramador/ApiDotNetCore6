using MP.ApiDotNet6.Domain.Validations;

namespace MP.ApiDotNet6.Domain.Entities
{
    public sealed class PersonImage
    {
        public PersonImage(int personId, string? imageUri, string? imageBase)
        {
            Validation(personId);
            ImageUri = imageUri;
            ImageBase = imageBase;
        }

        public int Id { get; private set; }
        public int PersonId { get; private set; }
        public string? ImageUri { get; private set; }
        public string? ImageBase { get; private set; }
        public Person Person { get; set; }

        private void Validation(int personId)
        {
            DomainValidationException.When(personId == 0, "Id pessoa deve ser informado");            
            PersonId = personId;
        }
    }
}