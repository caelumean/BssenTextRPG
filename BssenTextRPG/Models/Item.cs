using System;

namespace TextRPG.Models
{
    public abstract class Item
    {
        #region 프로퍼티
        // 아이템 이름
        // 아이템은 상속받은 클래스에서만 값을 write할 수 있도록 protected
        public string Name { get; protected set; } 
        
        // 아이템 설명
        public string Description { get; protected set; }

        // 아이템 가격
        public int Price {  get; protected set; }

        // 아이템 타입
        public ItemType Type { get; protected set; }
        #endregion

        #region 생성자
        protected Item(string name, string description, int price, ItemType type)
        {
            Name = name; 
            Description = description; 
            Price = price; 
            Type = type;
        }
        #endregion

        #region 메서드
        // 아이템 사용 메서드 (추상 메서드)
        // 플레이어가 갖고 있는 인벤토리 안에서
        // 아이템이 있는지 없는지 사용할 수 있는 여부를 나타내도록 하기 위해서
        public abstract bool Use(Player player);

        // 아이템 정보 표시 
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"[{Name}] {Description} (가격: {Price} 골드)");
        }
        #endregion
    }
}
