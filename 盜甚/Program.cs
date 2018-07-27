using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace 盜甚
{
    class Program
    {
        //物品欄
        public class Bag
        {
            public Item[] bag = new Item[3];
            public int len = 0;
            public Place now_place;
            public Bag(Place one)
            {
                now_place = one;
            }
            public void Show()
            {
                if (len != 0)
                {
                    Console.Write("攜帶物品：");
                    int t = 1;
                    foreach (Item i in bag)
                    {
                        try
                        {
                            Console.Write(t + "." + i.name + " ");
                            t++;
                        }
                        catch { }
                    }
                    Console.Write("\n輸入數字以查看或使用：");
                    string input = Console.ReadLine();
                    try
                    {
                        if (input == "1") bag[0].Use(this);
                        else if (input == "2") bag[1].Use(this);
                        else if (input == "3") bag[2].Use(this);
                        else Console.WriteLine("返回");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("輸入錯誤");
                    }
                }
                else
                {
                    Console.WriteLine("你還未取得任何東西");
                }
            }
            public void Add(Item i)
            {
                if (len == 3)
                {
                    Console.Write("攜帶物品：");
                    int t = 1;
                    foreach (Item it in bag)
                    {
                        Console.Write(t + "." + it.name + " ");
                        t++;
                    }
                    Console.WriteLine("\n物品欄滿了，請丟棄一樣物品(直接Enter取消)");
                    Throw(i);
                }
                else
                {
                    bag[len] = i;
                    len++;
                    Console.WriteLine("你取得了"+i.name);
                }
            }
            public void Throw(Item newget)
            {
                Console.Write("輸入要捨棄的物品編號：");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("你捨棄了"+bag[0].name);
                    bag[0] = newget;
                    Console.WriteLine("你取得了" + bag[0].name);
                }
                else if (input == "2")
                {
                    Console.WriteLine("你捨棄了" + bag[1].name);
                    bag[1] = newget;
                    Console.WriteLine("你取得了" + bag[1].name);
                }
                else if (input == "3")
                {
                    Console.WriteLine("你捨棄了" + bag[2].name);
                    bag[2] = newget;
                    Console.WriteLine("你取得了" + bag[2].name);
                }
                else Console.WriteLine("算了不要拿這個好了");
            }
            public bool Check(Item i)
            {
                bool c = false;
                foreach (Item x in bag)
                {
                    if (x == i) c = true;
                }
                return c;
            }
        }

        public class Item 
        {
            public string name;
            public string des;
            public bool taked;

            public virtual void Use(Bag b)
            {
                Console.WriteLine(des);
            }
        }

        public class Key : Item
        {
            public Key(string name,string des)
            {
                this.name = name;
                this.des = des;
            }
            public override void Use(Bag b)
            {
                Console.WriteLine(des);
                if (taked == false)
                {
                    Console.Write("要隨身攜帶嗎?(y/n) ");
                    if (Console.ReadLine() == "y")
                    {
                        taked = true;
                        b.Add(this);
                    }
                    else Console.WriteLine("放著就好");
                }
            }
        }

        public class Box : Item
        {
            public Item[] inside;

            public Box(string name, string des,Item[] inside)
            {
                this.name = name;
                this.des = des;
                this.inside = inside;
            }
            public override void Use(Bag b)
            {
                Console.WriteLine(des);
                int input = 0;
                Console.Write("調查:");
                int t = 1;
                foreach (Item i in inside)
                {
                    Console.Write(t + "." + i.name + " ");
                    t++;
                    if (i.taked == true) Console.Write("\b(已拿取) ");
                }
                try
                {
                    input = int.Parse(Console.ReadLine());
                    if (inside[input - 1].taked == false) inside[input - 1].Use(b);
                    else Console.WriteLine("此項物品已被拿走");
                }
                catch (FormatException)
                {
                    Console.WriteLine("你沒有理會它");
                }
            }
        }

        public class Weapon : Item
        {
            public Weapon(string name, string des)
            {
                this.name = name;
                this.des = des;
            }
            public override void Use(Bag b)
            {
                Console.Write(des + "\n你要自殺嗎?(y/n) ");
                string input = Console.ReadLine();
                if (input == "y")
                {
                    if (this.name == "手術刀")
                    {
                        Console.WriteLine("你拿起了銀色的手術刀...");
                        Thread.Sleep(1000);
                        Console.WriteLine("上面還留著你的血...");
                        Thread.Sleep(1000);
                        Console.WriteLine("為什麼要掙扎的活著呢?");
                        Thread.Sleep(1000);
                        Console.WriteLine("手術刀往左胸一送");
                        Thread.Sleep(1000);
                        Console.WriteLine("永別了...");
                        Thread.Sleep(1000);
                        Console.WriteLine("世界...");
                        Thread.Sleep(1000);
                        Console.WriteLine("\n遊戲結束，你自殺了");
                        Console.ReadLine();
                        System.Environment.Exit(System.Environment.ExitCode);
                    }
                    else if (this.name == "硫酸")
                    {
                        Console.WriteLine("你高舉裝著硫酸的玻璃瓶...");
                        Thread.Sleep(1000);
                        Console.WriteLine("從頭頂澆下...");
                        Thread.Sleep(1000);
                        Console.WriteLine("讓硫酸腐蝕你的頭髮...");
                        Thread.Sleep(1000);
                        Console.WriteLine("你的臉...");
                        Thread.Sleep(1000);
                        Console.WriteLine("以及你生存的希望...");
                        Thread.Sleep(1000);
                        Console.WriteLine("\n遊戲結束，你自殺了");
                        Console.ReadLine();
                        System.Environment.Exit(System.Environment.ExitCode);
                    }
                    else if (this.name == "安眠藥")
                    {
                        Console.WriteLine("也許就這樣睡著...");
                        Thread.Sleep(1000);
                        Console.WriteLine("夢是這麼的美好...");
                        Thread.Sleep(1000);
                        Console.WriteLine("為什麼要醒著呢...");
                        Thread.Sleep(1000);
                        Console.WriteLine("晚安...");
                        Thread.Sleep(1000);
                        Console.WriteLine("\n遊戲結束，你自殺了");
                        Console.ReadLine();
                        System.Environment.Exit(System.Environment.ExitCode);
                    }
                    else if (this.name == "手槍")
                    {
                        Console.WriteLine("我原本以為被槍口指著是一件很可怕的事");
                        Thread.Sleep(1000);
                        Console.WriteLine("但現在的我卻覺得很平靜");
                        Thread.Sleep(1000);
                        Console.WriteLine("希望不會太痛...");
                        Thread.Sleep(1000);
                        Console.WriteLine("碰...");
                        Thread.Sleep(1000);
                        Console.WriteLine("\n遊戲結束，你自殺了");
                        Console.ReadLine();
                        System.Environment.Exit(System.Environment.ExitCode);
                    }
                }
                else
                {
                    Console.WriteLine("不要放棄一絲希望");
                }

                if (taked == false)
                {
                    Console.Write("要隨身攜帶嗎?(y/n) ");
                    if (Console.ReadLine() == "y")
                    {
                        taked = true;
                        b.Add(this);
                    }
                    else Console.WriteLine("放著就好");
                }
            }
        }

        public class Door : Item
        {
            public Place a;
            public Place b;
            bool trigger = false;
            Mission mi;

            public Door(string name, Place a,Place b,Mission mi)
            {
                this.name = name;
                this.a = a;
                this.b = b;
                this.mi = mi;
            }
            public override void Use(Bag b)
            {
                if (b.now_place == a)
                {
                    b.now_place = this.b;
                    Console.WriteLine("你往" + this.b.name+"移動");
                }
                else if (b.now_place == this.b)
                {
                    b.now_place = this.a;
                    Console.WriteLine("你往" + this.a.name+"移動");
                }
                if (name == "門(手術間-臥房)" && trigger == false)
                {
                    mi.start = true;
                    trigger = true;
                }
            }
        }

        public class Phone : Item
        {
            bool trigger;
            public Mission M2;

            public Phone(string name,string des)
            {
                this.name = name;
                this.des = des;
                trigger = true;
            }
            public override void Use(Bag b)
            {
                Console.WriteLine(des);
                if (trigger == true)
                {
                    Console.Write("你要打電話向外界求援嗎?(y/n) ");
                    if (Console.ReadLine() == "y") Call();
                    else Console.WriteLine("還是不要冒險好了");
                }
            }
            private void Call()
            {
                Console.Clear();
                Console.WriteLine("你拿起話筒，準備打110求救");
                Thread.Sleep(1000);
                Console.WriteLine("但電話卻已經發出了撥號聲");
                Thread.Sleep(1000);
                Console.WriteLine("嘟....嘟....嘟....");
                Thread.Sleep(1000);
                Console.WriteLine("「你到了?這麼快!OK我三分鐘後去你那邊會合」");
                Thread.Sleep(1000);
                Console.WriteLine("電話被掛斷了...");
                Thread.Sleep(1000);
                M2.start = true;
                trigger = false;
            }
        }

        public class Changer : Item
        {
            public bool trigger;
            public Changer(string name,string des)
            {
                this.name = name;
                this.des = des;
                trigger = false;
            }
            public override void Use(Bag b)
            {
                Console.WriteLine(des);
                if (trigger == false)
                {
                    trigger = true;
                }
            }
        }

        public class Computer : Item
        {
            Changer password;
            Changer moniter;
            public bool trigger;
            int level;
            public Computer(string name,Changer password,Changer moniter)
            {
                this.name = name;
                level = 1;
                trigger = false;
                this.password = password;
                this.moniter = moniter;
            }
            public override void Use(Bag b)
            {
                if (level == 1 && password.trigger != true) Console.WriteLine("一台白色外殼的電腦，需要密碼才能登入");
                else if (level == 1 && password.trigger == true)
                {
                    Console.WriteLine("一台白色外殼的電腦，需要密碼才能登入");
                    Thread.Sleep(500);
                    Console.WriteLine("你試著輸入秘密通道使用的密碼，電腦鎖解開了");
                    level++;
                }
                else if (level == 2 && moniter.trigger == false)
                {
                    Console.WriteLine("一台白色外殼的電腦，密碼已經被解開了");
                }
                else if (level == 2 && moniter.trigger == true)
                {
                    Console.WriteLine("你想起了客廳的監視器");
                    Thread.Sleep(1000);
                    Console.WriteLine("一陣查找下發現了一段影像");
                    Thread.Sleep(1000);
                    Console.WriteLine("一個男人朝門的兩個底角踹了一下門就開了");
                    trigger = true;
                    level++;
                }
                else if (level == 3)
                {
                    Console.WriteLine("密碼鎖已經被解開了");
                }
            }
        }

        public class Sofa : Item
        {
            int level;
            Weapon gun;
            public Mission M3;

            public Sofa(string name, string des,Weapon gun)
            {
                this.name = name;
                this.des = des;
                level = 1;
                this.gun = gun;
            }
            public override void Use(Bag b)
            {
                Console.WriteLine(des);
                if (level == 1) level++;
                else if (level == 2) level++;
                else if (level == 3 && taked == false)
                {
                    Console.Write("沙發夾縫中藏著一把槍，是否要拿走(y/n)：");
                    if (Console.ReadLine() == "y")
                    {
                        M3.start = true;
                        b.Add(gun);
                        taked = true;
                    }
                    else Console.WriteLine("先不要亂動好了");
                }
            }
        }

        public class Bigdoor : Item
        {
            bool opened;
            public Place a;
            public Place b;
            Computer c;

            public Bigdoor(string name, string des, Computer c)
            {
                this.name = name;
                this.des = des;
                opened = false;
                this.c = c;
            }
            public override void Use(Bag b)
            {
                if (opened == false && c.trigger == true)
                {
                    opened = true;
                    Console.WriteLine("你也朝門的兩個底角踹了一下，門吱呀一聲地打開了");
                    Thread.Sleep(500);
                }
                if (opened == true)
                {
                    if (b.now_place == a)
                    {
                        b.now_place = this.b;
                        Console.WriteLine("你移動到了" + this.b.name);
                    }
                    else if (b.now_place == this.b)
                    {
                        b.now_place = this.a;
                        Console.WriteLine("你移動到了" + this.a.name);
                    }
                }
                else
                {
                    Console.WriteLine("一道重門，沒有手把也沒有鎖，打不開");
                }
            }
        }

        public class Teapot : Item
        {
            public int evill;
            Weapon pill;
            Weapon sulfuric;
            Item glass;
            public Mission M;

            public Teapot(Weapon pill,Weapon sulfuric,Item glass)
            {
                this.pill = pill;
                this.sulfuric = sulfuric;
                name = "茶壺";
                des = "一個鐵製的茶壺，裡面裝了八分滿的水";
                evill = 0;
                this.glass = glass;
            }
            public override void Use(Bag b)
            {
                if (evill == 0)
                {
                    Console.WriteLine(des);
                    if (b.Check(pill) || b.Check(sulfuric))
                    {
                        if (b.Check(sulfuric))
                        {
                            Console.Write("你要把硫酸倒在茶壺裡嗎?(y/n) ");
                            if (Console.ReadLine() == "y")
                            {
                                Console.WriteLine("你在裡面加入了硫酸");
                                evill = 1;
                                b.bag[Array.IndexOf(b.bag, sulfuric)] = glass;
                                M.start = true;
                            }
                        }
                        else if (b.Check(pill))
                        {
                            Console.Write("你要把安眠藥丟進茶壺裡嗎?(y/n) ");
                            if (Console.ReadLine() == "y")
                            {
                                Console.WriteLine("你在裡面摻了安眠藥");
                                evill = 2;
                                b.bag[Array.IndexOf(b.bag, pill)] = glass;
                                M.start = true;
                            }
                        }
                    }
                }
                else if (evill == 1)
                {
                    Console.WriteLine("一個鐵製的茶壺，裡面裝了你倒進去的硫酸");
                }
                else if(evill == 2)
                {
                    Console.WriteLine("一個鐵製的茶壺，裡面摻了你丟進去的安眠藥");
                }
            }
        }

        public class Car : Item
        {
            public Car()
            {
                name = "下山";
            }
            public override void Use(Bag b)
            {
                if (taked == false)
                {
                    Console.WriteLine("一條通往山下的路\n你要徒步走下山嗎?(y/n) ");
                    if (Console.ReadLine() == "y")
                    {
                        Console.WriteLine("你一步一步向下走");
                        Thread.Sleep(1000);
                        Console.WriteLine("路的坡度很陡，你好幾次差一點跌下去");
                        Thread.Sleep(1000);
                        Console.WriteLine("但你告訴自己");
                        Thread.Sleep(1000);
                        Console.WriteLine("我要活下去");
                        Thread.Sleep(1000);
                        Console.WriteLine("你一步一步向下走...");
                        Thread.Sleep(1000);
                        Console.WriteLine("\n遊戲結束，你還活著嗎?");
                        Thread.Sleep(1000);
                        Console.WriteLine("也許是吧");
                        Thread.Sleep(1000);
                        Console.WriteLine("也許已經被禿鷹啃成一具白骨");
                        Thread.Sleep(1000);
                        Console.WriteLine("你覺得呢?");
                        Console.ReadKey();
                        System.Environment.Exit(System.Environment.ExitCode);
                    }
                    else
                    {
                        Console.WriteLine("這樣走下去必死無疑，還是找找別的方法吧");
                    }
                }
                else
                {
                    Console.WriteLine("通往山下的路，一旁停著一輛轎車\n要開車離開嗎?(y/n) ");
                    if (Console.ReadLine() == "y")
                    {
                        Console.WriteLine("你上了車，油門一踩");
                        Thread.Sleep(1000);
                        Console.WriteLine("車子一路向前狂飆");
                        Thread.Sleep(1000);
                        Console.WriteLine("終於逃出了這個鬼地方");
                        Thread.Sleep(1000);
                        Console.WriteLine("\n遊戲結束，你成功逃走了");
                        Console.ReadKey();
                        System.Environment.Exit(System.Environment.ExitCode);
                    }
                    else
                    {
                        Console.WriteLine("你選擇留下");
                    }
                }
            }
        }

        public class Mission
        {
            public string name;
            public int delay;
            public int aldelay;
            public bool start;
            public Item key;
            public Item glass;
            public Weapon gun ;
            public Weapon knife ;
            public Teapot tea;
            bool stop;
            public Mission other;

            public Mission(string name,int delay,Item key,Item glass,Weapon gun,Weapon knife,Teapot tea)
            {
                this.name = name;
                this.delay = delay;
                aldelay = 0;
                start = false;
                this.key = key;
                this.glass = glass;
                this.gun = gun;
                this.knife = knife;
                this.tea = tea;
                stop = false;
            }
            public void Go(Bag b)
            {
                if (start == true && aldelay < delay) aldelay++;
                else if (start == true && aldelay == delay) Acting(b);
            }
            public void Acting(Bag b)
            {
                if (name == "生命之泉")
                {
                    Console.WriteLine("樓梯間很黑、很長，彷彿永遠走不到盡頭...");
                    Thread.Sleep(1500);
                    Console.WriteLine("你又餓又虛弱，感覺已經爬不動了...");
                    Thread.Sleep(1700);
                    if (Array.IndexOf(b.bag, key) != -1)
                    {
                        Console.WriteLine("你喝下了從櫥櫃裡拿走的葡萄糖，休息了一陣子後繼續往上爬，終於看到了出口");
                        b.bag[Array.IndexOf(b.bag, key)] = glass;
                        Thread.Sleep(1500);
                        Console.WriteLine("這是一個藏在書櫃後的密道");
                        Thread.Sleep(1000);
                        Console.WriteLine("不知道為甚麼是打開的狀態");
                    }
                    else
                    {
                        Console.WriteLine("絕望，大概就像這裡一樣，黯淡無光...");
                        Thread.Sleep(1500);
                        Console.WriteLine("你用盡了最後一點力氣，終究倒下了...");
                        Thread.Sleep(1500);
                        Console.WriteLine("\n遊戲結束，你摔下樓梯死了");
                        Console.ReadKey();
                        System.Environment.Exit(System.Environment.ExitCode);
                    }
                    Thread.Sleep(1000);
                    start = false;
                }
                else if(name == "黨羽")
                {
                    if (aldelay < delay) aldelay++;
                    else if(aldelay == delay)
                    {
                        Console.WriteLine("外頭傳來了車子引擎的聲音...");
                        key.taked = true;
                        Thread.Sleep(1500);
                        Console.WriteLine("「欸!劊子手，Boss說這個人的兩顆腎臟還不夠用，等等還要再抓一個來...");
                        Thread.Sleep(1500);
                        Console.WriteLine("「劊子手?? 在嗎?? 凡軒??」");
                        Thread.Sleep(1500);
                        if (b.Check(gun) || b.Check(knife)){
                            if (b.Check(gun))
                            {
                                Console.WriteLine("你躲在書房裡，打開一個門縫");
                                Thread.Sleep(1500);
                                Console.WriteLine("在他看見你的那個瞬間");
                                Thread.Sleep(1500);
                                Console.WriteLine("碰!!!");
                                Thread.Sleep(1500);
                                Console.WriteLine("那個男人死了...");
                                Thread.Sleep(1500);
                                start = false;
                                Console.WriteLine("你把他的屍體拖進了地下室");
                            }
                            else if (b.Check(knife))
                            {
                                if (b.now_place.name != "客廳")
                                {
                                    Console.WriteLine("那個男人到處查看房間");
                                    Thread.Sleep(1500);
                                    Console.WriteLine("「凡軒你在嗎?」");
                                    Thread.Sleep(1500);
                                    Console.WriteLine("在他靠近" + b.now_place.name + "的瞬間");
                                    Thread.Sleep(1500);
                                    Console.WriteLine("你把手術刀往他腦門上插下去");
                                    Thread.Sleep(1500);
                                    Console.WriteLine("一刀又一刀");
                                    Thread.Sleep(1500);
                                    Console.WriteLine("把那個男人的頭刺成了海綿");
                                    Thread.Sleep(1500);
                                    start = false;
                                    Console.WriteLine("你把他的屍體拖進了地下室");
                                }
                                else
                                {
                                    Console.WriteLine("那個人掃視了一遍客廳，看到了躲在沙發後面的你");
                                    Thread.Sleep(1500);
                                    Console.WriteLine("在一瞬間就掏出槍");
                                    Thread.Sleep(1000);
                                    Console.WriteLine("碰!!!");
                                    Thread.Sleep(1000);
                                    Console.WriteLine("\n遊戲結束，你被射殺了");
                                    Console.ReadKey();
                                    System.Environment.Exit(System.Environment.ExitCode);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("那個男人到處查看房間");
                            Thread.Sleep(1500);
                            Console.WriteLine("「凡軒你在嗎?」");
                            Thread.Sleep(1500);
                            Console.WriteLine("「幹!!!」");
                            Thread.Sleep(1000);
                            Console.WriteLine("他在發現你的瞬間從腰間拔出手槍");
                            Thread.Sleep(1000);
                            Console.WriteLine("「不要殺.....");
                            Thread.Sleep(1000);
                            Console.WriteLine("碰!!!");
                            Thread.Sleep(1500);
                            Console.WriteLine("\n遊戲結束，你被射殺了");
                            Console.ReadKey();
                            System.Environment.Exit(System.Environment.ExitCode);
                        }
                    }
                }
                else if(name == "倒數計時" && stop!=true)
                {
                    if (aldelay < delay) aldelay++;
                    else if (aldelay == delay)
                    {
                        Console.WriteLine("「原來你醒來了」");
                        Thread.Sleep(1000);
                        Console.WriteLine("一名男子忽然出現在你身後");
                        Thread.Sleep(1500);
                        Console.WriteLine("你慢慢轉過身");
                        Thread.Sleep(1000);
                        Console.WriteLine("是一個很年輕的帥哥");
                        Thread.Sleep(1000);
                        Console.WriteLine("身上穿著純白的醫師袍");
                        Thread.Sleep(1000);
                        Console.WriteLine("正拿槍指著你");
                        Thread.Sleep(1000);
                        Console.WriteLine("「我知道你想問甚麼」");
                        Thread.Sleep(1500);
                        Console.WriteLine("「拿起手槍會觸發警報」");
                        Thread.Sleep(1500);
                        Console.WriteLine("你伸手準備掏槍");
                        Thread.Sleep(1500);
                        Console.WriteLine("砰!!!");
                        Thread.Sleep(1000);
                        Console.WriteLine("你的手被射中了");
                        Thread.Sleep(1000);
                        Console.WriteLine("碰!!!");
                        Thread.Sleep(300);
                        Console.WriteLine("碰!!!");
                        Thread.Sleep(300);
                        Console.WriteLine("碰!!!");
                        Thread.Sleep(1000);
                        Console.WriteLine("你的四肢都被射中了");
                        Thread.Sleep(1500);
                        Console.WriteLine("漸漸的昏了過去");
                        Thread.Sleep(1500);
                        Console.WriteLine("\n遊戲結束，你僅存的一個腎也被摘走了");
                        Console.ReadKey();
                        System.Environment.Exit(System.Environment.ExitCode);
                    }
                }
                else if(name == "復仇")
                {
                    if (aldelay < delay) aldelay++;
                    else if (aldelay == delay)
                    {
                        if (tea.evill == 1 && b.now_place.name!="客廳" && b.now_place.name!="廚房")
                        {
                            Console.WriteLine("外頭有動靜");
                            Thread.Sleep(1000);
                            Console.WriteLine("趕緊找個地方躲起來");
                            Thread.Sleep(1000);
                            Console.WriteLine("你隱約聽到有一個人進了房子");
                            Thread.Sleep(1500);
                            Console.WriteLine("把東西放在客廳後");
                            Thread.Sleep(1500);
                            Console.WriteLine("慢慢走向廚房");
                            Thread.Sleep(1500);
                            Console.WriteLine("「太棒了...」你心想");
                            Thread.Sleep(1000);
                            Console.WriteLine("「啊.....啊...」");
                            Thread.Sleep(1000);
                            Console.WriteLine("「啊.....」");
                            Thread.Sleep(700);
                            Console.WriteLine("「啊.....」");
                            Thread.Sleep(300);
                            Console.WriteLine("「啊.....」");
                            Thread.Sleep(300);
                            Console.WriteLine("「啊.....」");
                            Thread.Sleep(300);
                            Console.WriteLine("「啊.....」");
                            Thread.Sleep(300);
                            Console.WriteLine("慘烈的叫聲傳遍了整間屋子");
                            Thread.Sleep(1500);
                            Console.WriteLine("你走向廚房查看");
                            Thread.Sleep(1500);
                            Console.WriteLine("一個男人穿著白色的醫師袍");
                            Thread.Sleep(1500);
                            Console.WriteLine("臉已經被腐蝕到看不清楚了");
                            Thread.Sleep(1500);
                            Console.WriteLine("他就是...兇手吧...");
                            Thread.Sleep(1500);
                            Console.WriteLine("你把他的屍體拖進了地下室");
                            start = false;
                            key.taked = true;
                            other.stop = true;
                            Console.ReadKey();
                        }
                        else if(tea.evill == 2 && b.now_place.name != "客廳" && b.now_place.name != "廚房")
                        {
                            Console.WriteLine("外頭有動靜");
                            Thread.Sleep(1000);
                            Console.WriteLine("趕緊找個地方躲起來");
                            Thread.Sleep(1000);
                            Console.WriteLine("你隱約聽到有一個人進了房子");
                            Thread.Sleep(1500);
                            Console.WriteLine("把東西放在客廳後");
                            Thread.Sleep(1500);
                            Console.WriteLine("慢慢走向廚房");
                            Thread.Sleep(1500);
                            Console.WriteLine("「太棒了」你心想");
                            Thread.Sleep(1000);
                            Console.WriteLine("幾分鐘後，外面沒了聲響");
                            Thread.Sleep(1500);
                            Console.WriteLine("一名穿著白色醫師袍的男人癱倒在地上，睡著了");
                            Thread.Sleep(1500);
                            Console.WriteLine("你把他拖進了地下室");
                            start = false;
                            key.taked = true;
                            other.stop = true;
                            Console.ReadKey();
                        }
                    }
                }
            }
        }

        public class Place
        {
            public string name;
            public Item[] inside;

            public Place(string name, Item[] inside)
            {
                this.name = name;
                this.inside = inside;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("慢慢醒轉過來...");
            Thread.Sleep(1500);
            Console.WriteLine("你躺在一張病床上...");
            Thread.Sleep(1500);
            Console.WriteLine("四周是白色的牆壁...");
            Thread.Sleep(1500);
            Console.WriteLine("但是充滿血漬...");
            Thread.Sleep(1500);
            do
            {
                Console.Write("調查：1.自己的身體(請輸入1) ");
            }
            while (Console.ReadLine() != "1");
            Console.Clear();
            Thread.Sleep(300);
            Console.WriteLine("腰上有一道長長的刀口...");
            Thread.Sleep(1500);
            Console.WriteLine("裡面感覺空空的...");
            Thread.Sleep(1500);
            Console.WriteLine("還好你還有一點力氣能動...\n(按下Enter繼續)");
            Console.ReadKey();
            Console.Clear();

            //物件
            Weapon Scalpel = new Weapon("手術刀","銀色的手術刀，刀柄有點生鏽，刀鋒卻很銳利");
            Item[] knife = {Scalpel};
            Box surgical_rack = new Box("手術架", "搖搖欲墜的手術架，上面放著沾了血的手術刀", knife);
            Key c6h12o6 = new Key("葡萄糖罐","一罐玻璃瓶，上面標示這是葡萄糖");
            Weapon sulfuric = new Weapon("硫酸", "一罐玻璃瓶，上面標示這是硫酸");
            Item[] glasses = { c6h12o6, sulfuric };
            Box cupboard = new Box("櫥櫃","一個木製櫥櫃，裡面放著很多化學藥品",glasses);
            Key glass = new Key("空的玻璃瓶", "曾經裝有東西，現在已經空了");
            glass.taked = true;
            Weapon pill = new Weapon("安眠藥", "一個小罐子，裡面裝著常見的安眠藥");
            Item[] pilllist = { pill };
            Box bedside = new Box("床頭櫃","一個可供收納的床頭櫃，上面放著一個小罐子",pilllist);
            Phone phone = new Phone("電話","一台家用電話");
            Changer password = new Changer("密門的密碼鎖", "用來打開通道的四格密碼鎖，上面寫著4863");
            Changer moniter = new Changer("監視器","一台監視著門口的監視器");
            Computer computer = new Computer("電腦",password,moniter);
            Key pictrue = new Key("照片", "裡面是一位年輕的醫生拿著榮譽證書，笑得非常開心");
            pictrue.taked = true;
            Key diary = new Key("筆記本", "一本日記，裡面寫的大概都是命運弄人等等厭世的內容");
            diary.taked = true;
            Weapon gun = new Weapon("手槍","一把銀色手槍，拿起來非常吃力");
            Sofa sofa = new Sofa("沙發", "皮革製的沙發，看起來很高級", gun);
            Bigdoor bigdoor = new Bigdoor("大門", "一道厚重的門，上面沒有鎖也沒有門把，打不開",computer);
            Teapot tea = new Teapot(pill, sulfuric, glass);
            Key ice = new Key("冰箱", "裡面放著很多臟器，可能都是...人類的?");
            Key table = new Key("餐具", "吧台上只放著一人用的餐具");
            table.taked = true;
            ice.taked = true;
            Car car = new Car();
            //場景
            Item[] operating_thing = {surgical_rack,cupboard};
            Place operating_room = new Place("手術間",operating_thing);
            Item[] bathroom_thing = {bedside,phone,password,computer,pictrue,diary};
            Place bathroom = new Place("臥房", bathroom_thing);
            Item[] livingroom_thing = { sofa, bigdoor, moniter };
            Place livingroom = new Place("客廳", livingroom_thing);
            Item[] kitchen_thing = { tea, ice, table};
            Place kitchen = new Place("廚房", kitchen_thing);
            Item[] outside_thing = { car };
            Place outside = new Place("門外", outside_thing);
            //任務
            Mission M1 = new Mission("生命之泉",0,c6h12o6,glass,Scalpel,gun,tea);
            Mission M2 = new Mission("黨羽", 5, car, glass, gun, Scalpel,tea);
            phone.M2 = M2;
            Mission M3 = new Mission("倒數計時", 5, car, glass, gun, Scalpel,tea);
            sofa.M3 = M3;
            Mission M4 = new Mission("復仇", 5, car, glass, gun, Scalpel, tea);
            M4.other = M3;
            tea.M = M4;
            Mission[] milist = {M1,M2,M3,M4};
            //門
            Door OtoB = new Door("門(手術間-臥房)", operating_room, bathroom,M1);
            List<Item> list = new List<Item>(operating_room.inside);
            list.Insert(2, OtoB);
            operating_room.inside = list.ToArray();
            list = new List<Item>(bathroom.inside);
            list.Insert(6, OtoB);
            bathroom.inside = list.ToArray();
            Door BtoL = new Door("門(臥房-客廳)", bathroom, livingroom,M1);
            list = new List<Item>(bathroom.inside);
            list.Insert(6, BtoL);
            bathroom.inside = list.ToArray();
            list = new List<Item>(livingroom.inside);
            list.Insert(3, BtoL);
            livingroom.inside = list.ToArray();
            Door LtoK = new Door("門(客廳-廚房)", livingroom, kitchen, M1);
            list = new List<Item>(livingroom.inside);
            list.Insert(4, LtoK);
            livingroom.inside = list.ToArray();
            list = new List<Item>(kitchen.inside);
            list.Insert(3, LtoK);
            kitchen.inside = list.ToArray();
            bigdoor.a = livingroom;
            bigdoor.b = outside;
            list = new List<Item>(outside.inside);
            list.Insert(0, bigdoor);
            outside.inside = list.ToArray();
            //物品欄
            Bag b = new Bag(operating_room);
            while (true)
            {
                //先看有沒有任務
                foreach(Mission m in milist){
                    if (m.start) m.Go(b);
                }
                //看場景列出物件
                Console.WriteLine("地點：" + b.now_place.name);
                Console.Write("查看物品欄：i  調查：");
                int no = 1;
                foreach (Item t in b.now_place.inside)
                {
                    Console.Write(no +"."+ t.name+" ");
                    no++;
                }
                while (true)
                {
                    string input = Console.ReadLine();
                    try
                    {
                        int put = int.Parse(input);
                        b.now_place.inside[put - 1].Use(b);
                        break;
                    }
                    catch (Exception)
                    {
                        if (input == "i")
                        {
                            b.Show();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("輸入錯誤");
                        }
                    }
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}