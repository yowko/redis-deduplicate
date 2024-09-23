using NRedisStack;
using NRedisStack.RedisStackCommands;
using StackExchange.Redis;

ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379,password=pass.123");
IDatabase db = redis.GetDatabase();
BloomCommands bf = db.BF();

// 檢查 bloom filter key:bf100 是否存在 `value1` 這個成員
if (!bf.Exists("bf100","value1"))
{
    // 不存在就新增
    bf.Add("bf100", "value1");
}

// 直接對 bloom filter key:bf100 新增 `value1` 這個成員
if (!bf.Add("bf100", "value1"))
{
    // 如果結果不是 true 代表已經存在
    Console.WriteLine("value1 already exists");
}