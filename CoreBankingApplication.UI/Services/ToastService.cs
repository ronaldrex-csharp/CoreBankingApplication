using CoreBankingApplication.UI.Models;

namespace CoreBankingApplication.UI.Services
{
    public class ToastService
    {
        public Guid Id { get; } = Guid.NewGuid(); // optional (for debugging)

        public event Action<ToastMessage>? OnShow;

        public void ShowToast(string message, string type = "success")
        {
            OnShow?.Invoke(new ToastMessage
            {
                Message = message,
                Type = type
            });
        }
    }
}
