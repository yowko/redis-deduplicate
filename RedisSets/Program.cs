using StackExchange.Redis;

ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379,password=pass.123");
IDatabase db = redis.GetDatabase();

// 檢查 sets key:sets100 是否存在 `value1` 這個成員
if (!db.SetContains("sets100", "value1"))
{
    // 不存在就新增
    db.SetAdd("sets100", "value1");
}

// 直接對 sets key:sets100 新增 `value1` 這個成員
if (!db.SetAdd("sets100", "value1"))
{
    // 如果結果不是 true 代表已經存在
    Console.WriteLine("value1 already exists");
}