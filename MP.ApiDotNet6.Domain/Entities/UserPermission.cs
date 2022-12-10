using MP.ApiDotNet6.Domain.Validations;

namespace MP.ApiDotNet6.Domain.Entities
{
    public sealed class UserPermission
    {
        public UserPermission(int userId, int permissionId)
        {
            Validation(userId,permissionId);
        }

        public int Id { get; private set; }
        public int UserId { get; private set; }
        public int PermissionId { get; private set; }

        public User User {get; set;}
        public Permission Permission {get; set;}


        private void Validation(int userId, int permissionId)
        {
            DomainValidationException.When(userId == 0, "Id usuário deve ser informado");            
            DomainValidationException.When(permissionId == 0, "Id permissão deve ser informado");            

            UserId = userId;
            PermissionId = permissionId;
        }
    }
}