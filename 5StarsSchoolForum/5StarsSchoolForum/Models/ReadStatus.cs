namespace _5StarsSchoolForum.Models
{
    internal class ReadStatus
    {
        [Flags]
        public enum ReadStatuses
        {
            NoNewPosts = 1,
            NewPosts = 2,
            Closed = 4,
            Open = 8,
            Pinned = 16,
            NotPinned = 32
        }
    }
}