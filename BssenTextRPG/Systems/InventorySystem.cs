using System;
// List 쓸려면 필요
using System.Collections.Generic;
using TextRPG.Models;
using TextRPG.Utils;

namespace TextRPG.Systems
{
    public class InventorySystem
    {
        #region 프로퍼티
        // 아이템 목록
        private List<Item> Items {  get; set; }

        // 아이템 갯수 ( =>는 읽기 전용으로 선언한 것이다.)
        public int Count => Items.Count;   // goes to

        // 위의 문법이랑 똑같은 내용이다.
        //public int Count
        //{
        //    get {  return Items.Count; }
        //}

        #endregion

        #region 생성자

        public InventorySystem() 
        {
            Items = new List<Item>();
        }
        #endregion

        #region 아이템 관리

        // 아이템 추가
        public void AddItem(Item item)
        {
            // Add로 List에 추가
            Items.Add(item);
            Console.WriteLine($"{item.Name}을 인벤토리에 추가했습니다.");
        }
        // 아이템 삭제
        public bool RemoveItem(Item item)
        {
            if(Items.Remove(item))
            {
                Console.WriteLine($"{item.Name}을 인벤토리에서 제거했습니다.");
                return true;
            }

            return false;
        }

        // 인덱스 값으로 아이템 반환
        public Item? GetItem(int index)
        {
            if (index >= 0 && index < Items.Count)
            {
                return Items[index];
            }
            return null;
        }
        #endregion

        #region 인벤토리 표시
        public void DisplayInventory()
        {
            Console.Clear();
            Console.WriteLine("\n╔════════════════════════════════╗");
            Console.WriteLine("║         인벤토리               ║");
            Console.WriteLine("╚════════════════════════════════╝");

            if (Items.Count == 0)
            {
                Console.WriteLine("인벤토리가 비어있습니다.");
                return;
            }

            Console.WriteLine("\n[보유아이템]");
            for(int i=0; i< Items.Count; i++)
            {
                Console.Write($"[{i + 1}] ");
                Items[i].DisplayInfo();
            }
        }
        public void ShowInventoryMenu(Player? player)
        {
            while(true)
            {
                DisplayInventory();

                Console.WriteLine("\n선택하세요.");
                Console.WriteLine("1.아이템 사용");
                Console.WriteLine("2.아이템 버리기");
                Console.WriteLine("0.나가기");
                Console.Write("선택: ");
                string? input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        //아이템사용로직
                        UseItem(player);
                        break;
                    case "2":
                        //아이템 버리기로직
                        DropItem(player);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("잘못된 선택입니다. 다시 선택하세요.");
                        break;
                }

            }
        }
        #endregion

        #region 아이템 사용
        private void UseItem(Player player)
        {
            if(Items.Count == 0)
            {
                Console.WriteLine("인벤토리가 비어있습니다.");
                return;
            }

            Console.Write("\n사용할 아이템 번호(0:취소)> ");
            // 콘솔에서 값을 입력할 때까지 대기
            // 그리고 int타입으로 변환시킨다.
            // 성공적으로 받으면 out 키워드에다가 저장한다.
            if(int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= Items.Count)
            {
                // 배열은 0번부터 시작한다.
                // 그래서 입력받은 값에 -1을 해야지 일치한다.
                Item item = Items[index - 1];

                if(item.Use(player))
                {
                    // 소모품일 경우 사용 후 리스트에서 제거하기
                    // is 키워드 item이 Consumable타입이면
                    if(item is Consumable)
                    {
                        RemoveItem(item);
                    }
                }
            }
            else if(index != 0)
            {
                Console.WriteLine("잘못된 선택입니다.");
                ConsoleUI.PressAnyKey();
            }
        }
        #endregion
        #region 아이템 버리기

        private void DropItem(Player player)
        {
            if(Items.Count == 0)
            {
                return;
            }

            Console.WriteLine("\n버릴 아이템 번호 (0:취소)> ");

            // 입력받는 값의 범위를 지정
            // 입력 받은 값과 index가 0보다 크고 index가 count보다 작아야한다.
            if(int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= Items.Count)
            {
                Item item = Items[index - 1];
                Console.Write($"정말 {item.Name}을 버리겠습니까? (y/n)");

                // ToLower는 입력받은 글자를 전부다 소문자로 바꿔준다.
                if(Console.ReadLine()?.ToLower() == "y")
                {
                    // 장착 해제 로직
                    if(item is Equipment equipment)
                    {
                        // 플레이어가 장착하고 있는 무기인지
                        if(equipment == player.EquipedWeapon)
                        {
                            player.UnequipItem(EquipmentSlot.Weapon);
                        }
                        else if(equipment == player.EquipedArmor)
                        {
                            player.UnequipItem(EquipmentSlot.Armor);
                        }
                    }
                   
                    RemoveItem(item);

                    Console.WriteLine($"{item.Name}을 버렸습니다.");
                    ConsoleUI.PressAnyKey();
                    
                }
            }
            else if (index != 0)
            {
                Console.WriteLine("잘못된 선택입니다.");
                ConsoleUI.PressAnyKey();
            }
        }


        #endregion
    }
}
