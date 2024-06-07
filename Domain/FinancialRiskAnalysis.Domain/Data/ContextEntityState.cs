namespace FinancialRiskAnalysis.Domain;

public enum ContextEntityState
{
    /// <summary>
    /// Karşılığı bulunmayan durumu ifade etmek için.
    /// </summary>
    Unknown = -1,

    /// <summary>
    /// Nesne'nin Context tarafından izlenmediğini belirtmek için.
    /// </summary>
    Detached = 0,

    /// <summary>
    /// Nesne, Context tarafından izleniyor, db de mevcut ve değeri değişmemiş ise kullanılır.
    /// </summary>
    Unchanged = 1,

    /// <summary>
    /// Veri tabanın dan silmek için kullanılır.
    /// </summary>
    Deleted = 2,

    /// <summary>
    /// Nesne'nin veri tabanın da ki değerini değiştirmek için kullanılır.
    /// </summary>
    Modified = 3,

    /// <summary>
    /// Veri tabanına eklemek için kullanılır.
    /// </summary>
    Added = 4,
}
