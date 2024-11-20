using System;

namespace Server.Items
{
    public class DecorativeDungeonSet : Backpack
    {
        public override int LabelNumber { get { return 1159468; } } // Decorative Dungeon Set

        [Constructable]
        public DecorativeDungeonSet()
        {
            DropItem(new DecorativeWallHook());
            DropItem(new DecorativeDungeonChair());
            DropItem(new DecorativeDungeonStool());
            DropItem(new DecorativeStocks());
            DropItem(new DecorativeDungeonMask());
            DropItem(new DungeonFountainDeed());
            DropItem(new DungeonBullDeed());
        }

        public DecorativeDungeonSet(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
