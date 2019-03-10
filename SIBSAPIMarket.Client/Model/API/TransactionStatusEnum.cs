namespace SIBSAPIMarket.Client.Model.API
{
    public enum TransactionStatusEnum
    {
        Received,
        Pending,
        PartiallyAcceptedTechnicallyCorrect,
        AcceptedTechnicalValidation,
        AcceptedCustomerProfile,
        AcceptedFundsChecked,
        AcceptedWithChanges,
        AcceptedSettlementInProgress,
        AcceptedSettlementCompleted,
        Rejected,
        Cancelled
    }
}
