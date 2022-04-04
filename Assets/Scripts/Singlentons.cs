public class Singlentons
{
    private static PersonModel _personModel;
    private static InventoryModel _inventoryModel;
    private static GameStatusModel _gameStatus;
    private static ItemsModel _itemsModel;
    private static DataModel _dataModel;

    public static ItemsModel GetItemsModel()
    {
        if (_itemsModel is null)
        {
            _itemsModel = new ItemsModel();
        }

        return _itemsModel;
    }
    
    public static GameStatusModel GetGameStatus()
    {
        if (_gameStatus is null)
        {
            _gameStatus = new GameStatusModel();
        }

        return _gameStatus;
    }

    public static void SetGameStatus(GameStatusModel gameStatus)
    {
        _gameStatus = gameStatus;
    }
    
    public static PersonModel GetPersonModel()
    {
        if (_personModel is null)
        {
            _personModel = new PersonModel();
        }

        return _personModel;
    }

    public static void SetPersonModel(PersonModel personModel)
    {
        _personModel = personModel;
    }

    public static InventoryModel GetInventoryModel()
    {
        if (_inventoryModel is null)
        {
            _inventoryModel = new InventoryModel();
        }

        return _inventoryModel;
    }

    public static void SetInventoryModel(InventoryModel inventoryModel)
    {
        _inventoryModel = inventoryModel;
    }
}
