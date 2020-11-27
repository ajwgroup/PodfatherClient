namespace PodfatherClient.Models
{
    public class PodPdf
    {
        private byte[] bytes;

        public PodPdf(byte[] bytes)
        {
            this.bytes = bytes;
        }

        public byte[] GetBytes()
        {
            return this.bytes;
        }
    }
}