using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Text_RPG_RtanDungeon
{
    internal class Program
    {
        public static List<string> item = new List<string>();
        public static List<int> itemGold = new List<int>();
        public static List<string> playerInventory = new List<string>();
        public static bool equipSwich = false;

        public static int totlaGold = 1000;



        public static void List()                                                                          //리스트 
        {

            item.Add("수련자 갑옷\t|" + "방어력 +" + 5 + "\t" + "|수련에 도움을 주는 갑옷입니다. |");
            item.Add("무쇠갑옷\t|" + "방어력 +" + 9 + "\t" + "|무쇠로 만들어져 튼튼한 갑옷입니다.|");
            item.Add("스파르타의갑옷\t|" + "방어력 +" + 15 + "\t" + "|스파르타의 전사들이 사용했다는 전설의 갑옷입니다.|");
            item.Add("낡은 검  \t|" + "공격력 +" + 2 + "\t" + "|쉽게 볼 수 있는 낡은 검 입니다.|");
            item.Add("청동 도끼\t|" + "공격력 +" + 5 + "\t" + "|어디선가 사용됐던거 같은 도끼입니다.|");
            item.Add("스파르타의 창\t|" + "공격력 +" + 7 + "\t" + "|스파르타의 전사들이 사용했다는 전설의 창입니다.|");

            itemGold.Add(1000);
            itemGold.Add(100);
            itemGold.Add(3500);
            itemGold.Add(600);
            itemGold.Add(1500);
            itemGold.Add(100);

        }
        public static void MainScreen()                                                                       // 메인 화면
        {
            Console.WriteLine(" ");
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine(" ");
            Console.WriteLine("1. 상태 보기 ");
            Console.WriteLine("2. 인벤토리 ");
            Console.WriteLine("3. 상점 ");
            Console.WriteLine(" ");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");


            int numberOut = int.Parse(Console.ReadLine());
            if (numberOut == 1)
            {
                CheckStatus();
            }
            else if (numberOut == 2)
            {
                Inventory();
            }
            else if (numberOut == 3)
            {
                Shop();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다");
                MainScreen();
            }
            
        }

        static void Main(string[] args)
        {
            List();
            MainScreen();

        }




        static public int AddAttStatus()                                                                      // 공격스텟 
        {
            int att = 0;
            int updateAttStatus = 0;
            foreach (string item in playerInventory)
            {

                if (item.Contains("[E]") && item.Contains("공격력"))
                {
                    string[] itemAtt = item.Split('+', '|');
                    string attStatus = itemAtt[2];
                    att = int.Parse(attStatus);
                    updateAttStatus += att;

                }

            }
            return updateAttStatus;
        }



        static public int AddDepStatus()                                                                      //방어스텟
        {
            int Dep = 0;
            int updateDepStatus = 0;
            foreach (string item in playerInventory)
            {
                if (item.Contains("[E]") && item.Contains("방어력"))
                {
                    string[] itemDep = item.Split('+', '|');
                    string depStatus = itemDep[2];
                    Dep = int.Parse(depStatus);
                    updateDepStatus += Dep;
                }
            }
            return updateDepStatus;
        }




        static public void CheckStatus()                                                                      //상태보기
        {
            Console.WriteLine(" ");
            int attStatus = 10;
            int depStatus = 5;
            int attTotalStatus = attStatus + AddAttStatus();
            int depTotalStatus = depStatus + AddDepStatus();

            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine(" ");

            Console.WriteLine("Lv. 01 ");
            Console.WriteLine("Chad ( 전사 ) ");
            Console.WriteLine("공격력 :" + attTotalStatus + "(" + AddAttStatus() + ")");
            Console.WriteLine("방어력 :" + depTotalStatus + "(" + AddDepStatus() + ")");
            Console.WriteLine("체 력 : 100 ");
            Console.WriteLine("Gold :" + totlaGold + " G ");
            Console.WriteLine(" ");

            Console.WriteLine("0. 나가기 ");
            Console.WriteLine("  ");

            Console.WriteLine("원하시는 행동을 입력해주세요. ");
            Console.Write(">> ");


            int numberOut = int.Parse(Console.ReadLine());
            if (numberOut == 0)
            {
                MainScreen();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다");
                CheckStatus();
            }
            
        }







        static public void Inventory()                                                                       //인벤토리 
        {
            Console.WriteLine(" ");
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine(" ");

            Console.WriteLine("[아이템 목록] ");

            foreach (string itemList in playerInventory)
            {

                Console.WriteLine(itemList);

            }


            Console.WriteLine(" ");

            Console.WriteLine("1. 장착관리");
            Console.WriteLine("0. 나가기 ");
            Console.WriteLine("  ");

            Console.WriteLine("원하시는 행동을 입력해주세요. ");
            Console.Write(">> ");


            int numberOut = int.Parse(Console.ReadLine());
            if (numberOut == 0)
            {
                MainScreen();
            }
            else if (numberOut == 1)
            {
                ManageEquipment();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다");
                Inventory();
            }
            
        }










        static public void ManageEquipment()                                                       //장착관리
        {
            Console.WriteLine(" ");
            Console.WriteLine("인벤토리-장착관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine(" ");

            Console.WriteLine("[아이템 목록] ");
            int itemNumbber = 1;

            foreach (string itemList in playerInventory)
            {

                Console.WriteLine(itemNumbber + itemList);
                itemNumbber++;
            }
            Console.WriteLine(" ");

            Console.WriteLine("0. 나가기 ");
            Console.WriteLine("  ");

            Console.WriteLine("원하시는 행동을 입력해주세요. ");
            Console.Write(">> ");


            int numberOut = int.Parse(Console.ReadLine());
            if (numberOut == 0)
            {
                Inventory();
            }
            else if (numberOut > 0 && numberOut < 7)
            {

                if (equipSwich == false)
                {
                    equipSwich = true;
                    playerInventory.Add("[E] " + playerInventory[numberOut - 1]);
                    playerInventory.Remove(playerInventory[numberOut - 1]);
                    ManageEquipment();
                }
                else
                {
                    equipSwich = false;
                    playerInventory.Remove(playerInventory[numberOut - 1]);
                    playerInventory.Add(item[numberOut - 1]);
                    ManageEquipment();
                }

            }

            else
            {
                Console.WriteLine("잘못된 입력입니다");
                ManageEquipment();
            }
            
        }



        public static bool ECheck(string name)                                          //구매확인용 [E] 체크
        {
            foreach (string item1 in playerInventory)
            {
                string eRemoveItem = item1.Replace("[E]", "");
                if (eRemoveItem == name)
                {

                    return true;

                }
            }
            return false;
        }




        public static void ShopBuy()                                                       //아이템 구매
        {
            Console.WriteLine(" ");
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");

            Console.WriteLine(" ");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine(totlaGold + "G");

            Console.WriteLine(" ");
            Console.WriteLine("[아이템 목록] ");
            for (int i = 0; i < item.Count; i++)
            {
                if (ECheck(item[i]))
                {
                    Console.WriteLine($"{i + 1}{item[i]} (구매완료)");
                }
                else
                {
                    Console.WriteLine($"{i + 1}{item[i]} {itemGold[i]}G");
                }
            }

            Console.WriteLine("");
            Console.WriteLine("0. 나가기");

            Console.WriteLine(" ");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");


            int numberOut = int.Parse(Console.ReadLine());
            if (numberOut == 0)
            {
                Shop();
            }
            else if (numberOut > 0 && numberOut < 7)
            {

                int i = numberOut - 1;
                if (ECheck(item[i]))
                {
                    Console.WriteLine("이미 구매한 아이템입니다");
                    

                }
                else if (totlaGold < ItemPrice(i))
                {
                    Console.WriteLine("Gold 가 부족합니다.");
                    

                }
                else
                {
                    Console.WriteLine("구매를 완료하였습니다");
                    playerInventory.Add(item[i]);
                    totlaGold -= ItemPrice(i);
                }
                ShopBuy();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다");
                ShopBuy();
            }
            
        }




        public static void Shop()                                                          //상점
        {
            Console.WriteLine(" ");
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");

            Console.WriteLine(" ");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine(totlaGold + "G");

            Console.WriteLine(" ");
            Console.WriteLine("[아이템 목록] ");

            for (int i = 0; i < item.Count; i++)
            {
                if (ECheck(item[i]))
                {
                    Console.WriteLine($"{item[i]} (구매완료)");
                }
                else
                {
                    Console.WriteLine($"{item[i]} {itemGold[i]}G");
                }
            }
            Console.WriteLine("");
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");

            Console.WriteLine(" ");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");


            int numberOut = int.Parse(Console.ReadLine());
            if (numberOut == 0)
            {
                MainScreen();
            }
            else if (numberOut == 1)
            {
                ShopBuy();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다");
                Shop();
            }
            
        }



        public static int ItemPrice(int itemstep)                                    // 아이템 골드 계산용
        {
            int price = itemGold[itemstep];

            return price;

        }
    }
}
