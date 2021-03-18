namespace CNode.Domain.Entities
{
    public class GitAccount
    {
        public int Id { get; set; }
        public int GitUserId { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }

        public int GitToolId { get; set; }
        public GitTool GitTool { get; set; }
    }
}
