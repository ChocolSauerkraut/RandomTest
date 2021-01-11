using System;
using System.Collections.Generic;

namespace RandomTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = new RewardAbilitySystem(Math.Abs((int)System.DateTime.Now.Ticks));
            while (true)
            {
                Console.ReadKey();
                system.RandomAbility();
            }

        }
    }

    class RewardAbilitySystem 
    {
        private Random _intRandom;
        private Random _random;
        private Dictionary<int, List<object>> _pool = new Dictionary<int, List<object>>();
        public RewardAbilitySystem(int seed) 
        {
            _intRandom = new Random(seed);
            _random = new Random(seed);
            _pool = new Dictionary<int, List<object>>() 
            {
                { 1, new List<object>{ 0, 0, 0, 0, 0} },
                { 2, new List<object>{ 0, 0, 0, 0,  } },
                { 4, new List<object>{ 0, 0, 0, 0, 0} },
                { 3, new List<object>{ 0, 0, 0,     } },

            };
        }
        public void RandomAbility(int count = 3, bool allowances = false)
        {
            Console.Clear();
            for (int i = 0; i < count; i++)
            {
                int type = RandomAbilityType();
                if (allowances && i == count - 1)
                {
                    type = RewardAbilitySetting.Allowances;
                }

                if (_pool.TryGetValue(type, out var list))
                {
                    int index = RandomRange(0, list.Count);
                    Console.WriteLine($"{0}----{list.Count}----{index}");
                    //rewardComp.Abilities[i] = list[index].id;
                }
            }
        }

        private int RandomAbilityType()
        {
            float randomValue = RandomRange(0f, 100f);
            float probability = 0;
            foreach (var item in RewardAbilitySetting.Probability)
            {
                int type = item.Key;
                probability += item.Value * 100;
                if (randomValue <= probability)
                {
                    return type;
                }
            }
            //_logger.Error("random ability failed");
            return 0;
        }

        public float RandomRange(float min, float max)
        {
            var value = (float)(_random.NextDouble() * (max - min) + min);
            return value;
        }

        public int RandomRange(int min, int max)
        {
            return _intRandom.Next(min, max);
        }
    }

    public class RewardAbilitySetting
    {
        /// <summary>
        /// 各品阶类型
        /// </summary>
        public static readonly Dictionary<int, float> Probability = new Dictionary<int, float>
        {
            //品阶，概率
            { 1,    0.45f},
            { 2,    0.35f},
            { 3,    0.17f},
            { 4,    0.03f},
        };

        /// <summary>
        /// 低保品阶
        /// </summary>
        public static readonly int Allowances = 4;
    }
}
