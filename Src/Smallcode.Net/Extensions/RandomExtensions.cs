using System;
using System.Text;

namespace Smallcode.Net.Extensions
{
    public static class RandomExtensions
    {
        /// <summary>
        ///     获取随机指定长度的整数字符串
        /// </summary>
        /// <param name="random"></param>
        /// <param name="length">长度</param>
        /// <returns>整数字符串</returns>
        public static string NextIntString(this Random random, int length)
        {
            var sb = new StringBuilder();
            if (length > 0) sb.Append(random.Next(1, 10));
            for (var i = 1; i < length; i++)
            {
                sb.Append(random.Next(10));
            }
            return sb.ToString();
        }

        /// <summary>
        ///     获取随机指定长度的小数字符串
        /// </summary>
        /// <example>0.xxxx</example>
        /// <param name="random"></param>
        /// <param name="length">小数位后的长度</param>
        /// <returns>小数字符串 0.xxxx</returns>
        public static string NextDoubleString(this Random random, int length)
        {
            return "0." + random.NextIntString(length);
        }

        /// <summary>
        ///     获取随机字母串
        /// </summary>
        /// <param name="random"></param>
        /// <param name="size">长度</param>
        /// <param name="lowerCase">是否小写</param>
        /// <param name="check">检查字符串是否有效的函数</param>
        /// <returns>随机字符串</returns>
        public static string NextLetters(this Random random, int size, bool lowerCase = true, Func<string, bool> check = null)
        {
            var builder = new StringBuilder();
            for (var i = 0; i < size; i++)
            {
                builder.Append(Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65))));
            }
            var str = lowerCase ? builder.ToString().ToLower() : builder.ToString();
            if (check == null) return str;
            return check(str) ? str : random.NextLetters(size, lowerCase, check);
        }

        /// <summary>
        ///     获取随机字符串，包含字母和数字
        /// </summary>
        public static string NextString(this Random random, int chars)
        {
            var builder = new StringBuilder();
            for (var i = 0; i < chars; i++)
            {
                var x = random.Next(2);
                switch (x)
                {
                    case 0: builder.Append((char)(random.Next(10) + 48)); break; // 0-9
                    case 1: builder.Append((char)(random.Next(26) + 65)); break; // A-Z
                    case 2: builder.Append((char)(random.Next(26) + 97)); break; // a-z
                }
            }
            return builder.ToString();
        }

        private static readonly Lazy<string[]> ChineseFirstnames = new Lazy<string[]>(() => new[] { "张", "王", "李", "刘", "陈", "杨", "黄", "赵", "吴", "周", "徐", "孙", "马", "朱", "胡", "郭", "何", "高", "林", "罗", "郑", "梁", "谢", "宋", "唐", "许", "韩", "冯", "邓", "曹", "彭", "曾", "肖", "田", "董", "袁", "潘", "于", "蒋", "蔡", "余", "杜", "叶", "程", "苏", "魏", "吕", "丁", "任", "沈", "姚", "卢", "姜", "崔", "钟", "谭", "陆", "汪", "范", "金", "石", "廖", "贾", "夏", "韦", "付", "方", "白", "邹", "孟", "熊", "秦", "邱", "江", "尹", "薛", "闫", "段", "雷", "侯", "龙", "史", "陶", "黎", "贺", "顾", "毛", "郝", "龚", "邵", "万", "钱", "严", "覃", "武", "戴", "莫", "孔", "向", "汤" });
        private static readonly Lazy<string[]> ChineseGrilLastnames = new Lazy<string[]>(() => new[] { "蕊", "薇", "菁", "梦", "岚", "苑", "婕", "馨", "瑗", "琰", "韵", "融", "园", "艺", "咏", "卿", "聪", "澜", "纯", "爽", "琬", "茗", "羽", "希", "宁", "欣", "飘", "育", "滢", "馥", "筠", "柔", "竹", "霭", "凝", "晓", "欢", "霄", "伊", "亚", "宜", "可", "姬", "舒", "影", "荔", "枝", "思", "丽", "芬", "芳", "燕", "莺", "媛", "艳", "珊", "莎", "蓉", "眉", "君", "琴", "毓", "悦", "昭", "冰", "枫", "芸", "菲", "寒", "锦", "玲", "秋", "秀", "娟", "英", "华", "慧", "巧", "美", "娜", "静", "淑", "惠", "珠", "翠", "雅", "芝", "玉", "萍", "红", "月", "彩", "春", "菊", "兰", "凤", "洁", "梅", "琳", "素", "云", "莲", "真", "环", "雪", "荣", "爱", "妹", "霞", "香", "瑞", "凡", "佳", "嘉", "琼", "勤", "珍", "贞", "莉", "桂", "娣", "叶", "璧", "璐", "娅", "琦", "晶", "妍", "茜", "黛", "青", "倩", "婷", "姣", "婉", "娴", "瑾", "颖", "露", "瑶", "怡", "婵", "雁", "蓓", "纨", "仪", "荷", "丹" });
        private static readonly Lazy<string[]> ChineseBoyLastnames = new Lazy<string[]>(() => new[] { "栋", "维", "启", "克", "伦", "翔", "旭", "鹏", "泽", "晨", "辰", "士", "以", "建", "家", "致", "树", "炎", "盛", "雄", "琛", "钧", "冠", "策", "腾", "楠", "榕", "风", "航", "弘", "义", "兴", "良", "飞", "彬", "富", "和", "鸣", "朋", "斌", "行", "时", "泰", "博", "磊", "民", "友", "志", "清", "坚", "庆", "若", "德", "彪", "伟", "刚", "勇", "毅", "俊", "峰", "强", "军", "平", "保", "东", "文", "辉", "力", "明", "永", "健", "世", "广", "海", "山", "仁", "波", "宁", "福", "生", "龙", "元", "全", "国", "胜", "学", "祥", "才", "发", "武", "新", "利", "顺", "信", "子", "杰", "涛", "昌", "成", "康", "星", "光", "天", "达", "安", "岩", "中", "茂", "进", "林", "有", "诚", "先", "敬", "震", "振", "壮", "会", "思", "群", "豪", "心", "邦", "承", "乐", "绍", "功", "松", "善", "厚", "裕", "河", "哲", "江", "超", "浩", "亮", "政", "谦", "亨", "奇", "固", "之", "轮", "翰", "朗", "伯", "宏", "言" });

        /// <summary>
        /// 获取随机女性姓名
        /// </summary>
        public static string NextChineseGirlFullname(this Random random)
        {
            var fristnames = ChineseFirstnames.Value;
            var lastnames = ChineseGrilLastnames.Value;
            return fristnames[random.Next(fristnames.Length)] + lastnames[random.Next(lastnames.Length)] + lastnames[random.Next(lastnames.Length)];
        }

        /// <summary>
        /// 获取随机生成男性姓名
        /// </summary>
        public static string NextChineseBoyFullname(this Random random)
        {
            var fristnames = ChineseFirstnames.Value;
            var lastnames = ChineseBoyLastnames.Value;
            return fristnames[random.Next(fristnames.Length)] + lastnames[random.Next(lastnames.Length)] + lastnames[random.Next(lastnames.Length)];
        }

        /// <summary>
        /// 获取随机布尔值
        /// </summary>
        public static bool NextBool(this Random random)
        {
            return random.NextDouble() > 0.5;
        }

        /// <summary>
        /// 获取随机枚举值
        /// </summary>
        public static T NextEnum<T>(this Random random) where T : struct
        {
            var type = typeof(T);
            if (type.IsEnum == false) throw new InvalidOperationException();

            var array = Enum.GetValues(type);
            var index = random.Next(array.GetLowerBound(0), array.GetUpperBound(0) + 1);
            return (T)array.GetValue(index);
        }

        /// <summary>
        /// 获取随机日期
        /// </summary>
        public static DateTime NextDateTime(this Random random, DateTime minValue, DateTime maxValue)
        {
            var ticks = minValue.Ticks + (long)((maxValue.Ticks - minValue.Ticks) * random.NextDouble());
            return new DateTime(ticks);
        }

        /// <summary>
        /// 获取随机日期
        /// </summary>
        public static DateTime NextDateTime(this Random random)
        {
            return NextDateTime(random, DateTime.MinValue, DateTime.MaxValue);
        }

        /// <summary>
        /// 获取随机生日
        /// </summary>
        /// <param name="random"></param>
        /// <param name="minAge">最小年龄</param>
        /// <param name="maxAge">最大年龄</param>
        /// <returns>随机生日</returns>
        public static DateTime NextBirthday(this Random random, int minAge, int maxAge)
        {
            return random.NextDateTime(DateTime.Now.AddYears(-maxAge), DateTime.Now.AddYears(-minAge));
        }
    }
}