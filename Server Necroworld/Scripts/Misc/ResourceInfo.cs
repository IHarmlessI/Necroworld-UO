using System;
using System.Collections;

namespace Server.Items
{
    public enum CraftResource
    {
        None = 0,
        Iron = 1,
        DullCopper,
        ShadowIron,
        Copper,
        Bronze,
        Gold,
        Agapite,
        Verite,
        Valorite,

        RegularLeather = 101,
        SpinedLeather,
        HornedLeather,
        BarbedLeather,

        RedScales = 201,
        YellowScales,
        BlackScales,
        GreenScales,
        WhiteScales,
        BlueScales,

        RegularWood = 301,
        OakWood,
        AshWood,
        YewWood,
        Heartwood,
        Bloodwood,
        Frostwood
    }

    public enum CraftResourceType
    {
        None,
        Metal,
        Leather,
        Scales,
        Wood
    }

    public class CraftAttributeInfo
    {
        private int m_WeaponFireDamage;
        private int m_WeaponColdDamage;
        private int m_WeaponPoisonDamage;
        private int m_WeaponEnergyDamage;
        private int m_WeaponChaosDamage;
        private int m_WeaponDirectDamage;
        private int m_WeaponDurability;
        private int m_WeaponLuck;
        private int m_WeaponGoldIncrease;
        private int m_WeaponLowerRequirements;
        private int m_WeaponDamage;
        private int m_WeaponHitChance;
        private int m_WeaponHitLifeLeech;
        private int m_WeaponRegenHits;
        private int m_WeaponSwingSpeed;
        private int m_WeaponDamageIncrease;

        private int m_ArmorPhysicalResist;
        private int m_ArmorFireResist;
        private int m_ArmorColdResist;
        private int m_ArmorPoisonResist;
        private int m_ArmorEnergyResist;
        private int m_ArmorDurability;
        private int m_ArmorLuck;
        private int m_ArmorGoldIncrease;
        private int m_ArmorLowerRequirements;
        private int m_ArmorDamage;
        private int m_ArmorHitChance;
        private int m_ArmorRegenHits;
        private int m_ArmorMage;

        private int m_ShieldPhysicalResist;
        private int m_ShieldFireResist;
        private int m_ShieldColdResist;
        private int m_ShieldPoisonResist;
        private int m_ShieldEnergyResist;
        private int m_ShieldPhysicalRandom;
        private int m_ShieldColdRandom;
        private int m_ShieldSpellChanneling;
        private int m_ShieldLuck;
        private int m_ShieldLowerRequirements;
        private int m_ShieldRegenHits;
        private int m_ShieldBonusDex;
        private int m_ShieldBonusStr;
        private int m_ShieldReflectPhys;
        private int m_SelfRepair;

        private int m_OtherSpellChanneling;
        private int m_OtherLuck;
        private int m_OtherRegenHits;
        private int m_OtherLowerRequirements;

        private int m_RunicMinAttributes;
        private int m_RunicMaxAttributes;
        private int m_RunicMinIntensity;
        private int m_RunicMaxIntensity;
        
        public int WeaponFireDamage { get { return m_WeaponFireDamage; } set { m_WeaponFireDamage = value; } }
        public int WeaponColdDamage { get { return m_WeaponColdDamage; } set { m_WeaponColdDamage = value; } }
        public int WeaponPoisonDamage { get { return m_WeaponPoisonDamage; } set { m_WeaponPoisonDamage = value; } }
        public int WeaponEnergyDamage { get { return m_WeaponEnergyDamage; } set { m_WeaponEnergyDamage = value; } }
        public int WeaponChaosDamage { get { return m_WeaponChaosDamage; } set { m_WeaponChaosDamage = value; } }
        public int WeaponDirectDamage { get { return m_WeaponDirectDamage; } set { m_WeaponDirectDamage = value; } }
        public int WeaponDurability { get { return m_WeaponDurability; } set { m_WeaponDurability = value; } }
        public int WeaponLuck { get { return m_WeaponLuck; } set { m_WeaponLuck = value; } }
        public int WeaponGoldIncrease { get { return m_WeaponGoldIncrease; } set { m_WeaponGoldIncrease = value; } }
        public int WeaponLowerRequirements { get { return m_WeaponLowerRequirements; } set { m_WeaponLowerRequirements = value; } }
        public int WeaponDamage { get { return m_WeaponDamage; } set { m_WeaponDamage = value; } }
        public int WeaponHitChance { get { return m_WeaponHitChance; } set { m_WeaponHitChance = value; } }
        public int WeaponHitLifeLeech { get { return m_WeaponHitLifeLeech; } set { m_WeaponHitLifeLeech = value; } }
        public int WeaponRegenHits { get { return m_WeaponRegenHits; } set { m_WeaponRegenHits = value; } }
        public int WeaponSwingSpeed { get { return m_WeaponSwingSpeed; } set { m_WeaponSwingSpeed = value; } }
        public int WeaponDamageIncrease { get { return m_WeaponDamageIncrease; } set { m_WeaponDamageIncrease = value; } }

        public int ArmorPhysicalResist { get { return m_ArmorPhysicalResist; } set { m_ArmorPhysicalResist = value; } }
        public int ArmorFireResist { get { return m_ArmorFireResist; } set { m_ArmorFireResist = value; } }
        public int ArmorColdResist { get { return m_ArmorColdResist; } set { m_ArmorColdResist = value; } }
        public int ArmorPoisonResist { get { return m_ArmorPoisonResist; } set { m_ArmorPoisonResist = value; } }
        public int ArmorEnergyResist { get { return m_ArmorEnergyResist; } set { m_ArmorEnergyResist = value; } }
        public int ArmorDurability { get { return m_ArmorDurability; } set { m_ArmorDurability = value; } }
        public int ArmorLuck { get { return m_ArmorLuck; } set { m_ArmorLuck = value; } }
        public int ArmorGoldIncrease { get { return m_ArmorGoldIncrease; } set { m_ArmorGoldIncrease = value; } }
        public int ArmorLowerRequirements { get { return m_ArmorLowerRequirements; } set { m_ArmorLowerRequirements = value; } }
        public int ArmorDamage { get { return m_ArmorDamage; } set { m_ArmorDamage = value; } }
        public int ArmorHitChance { get { return m_ArmorHitChance; } set { m_ArmorHitChance = value; } }
        public int ArmorRegenHits { get { return m_ArmorRegenHits; } set { m_ArmorRegenHits = value; } }
        public int ArmorMage { get { return m_ArmorMage; } set { m_ArmorMage = value; } }

        public int ShieldPhysicalResist { get { return m_ShieldPhysicalResist; } set { m_ShieldPhysicalResist = value; } }
        public int ShieldFireResist { get { return m_ShieldFireResist; } set { m_ShieldFireResist = value; } }
        public int ShieldColdResist { get { return m_ShieldColdResist; } set { m_ShieldColdResist = value; } }
        public int ShieldPoisonResist { get { return m_ShieldPoisonResist; } set { m_ShieldPoisonResist = value; } }
        public int ShieldEnergyResist { get { return m_ShieldEnergyResist; } set { m_ShieldEnergyResist = value; } }
        public int ShieldPhysicalRandom { get { return m_ShieldPhysicalRandom; } set { m_ShieldPhysicalRandom = value; } }
        public int ShieldColdRandom { get { return m_ShieldColdRandom; } set { m_ShieldColdRandom = value; } }
        public int ShieldSpellChanneling { get { return m_ShieldSpellChanneling; } set { m_ShieldSpellChanneling = value; } }
        public int ShieldLuck { get { return m_ShieldLuck; } set { m_ShieldLuck = value; } }
        public int ShieldLowerRequirements { get { return m_ShieldLowerRequirements; } set { m_ShieldLowerRequirements = value; } }
        public int ShieldRegenHits { get { return m_ShieldRegenHits; } set { m_ShieldRegenHits = value; } }
        public int ShieldBonusDex { get { return m_ShieldBonusDex; } set { m_ShieldBonusDex = value; } }
        public int ShieldBonusStr { get { return m_ShieldBonusStr; } set { m_ShieldBonusStr = value; } }
        public int ShieldReflectPhys { get { return m_ShieldReflectPhys; } set { m_ShieldReflectPhys = value; } }
        public int ShieldSelfRepair { get { return m_SelfRepair; } set { m_SelfRepair = value; } }

        public int OtherSpellChanneling { get { return m_OtherSpellChanneling; } set { m_OtherSpellChanneling = value; } }
        public int OtherLuck { get { return m_OtherLuck; } set { m_OtherLuck = value; } }
        public int OtherRegenHits { get { return m_OtherRegenHits; } set { m_OtherRegenHits = value; } }
        public int OtherLowerRequirements { get { return m_OtherLowerRequirements; } set { m_OtherLowerRequirements = value; } }

        public int RunicMinAttributes { get { return m_RunicMinAttributes; } set { m_RunicMinAttributes = value; } }
        public int RunicMaxAttributes { get { return m_RunicMaxAttributes; } set { m_RunicMaxAttributes = value; } }
        public int RunicMinIntensity { get { return m_RunicMinIntensity; } set { m_RunicMinIntensity = value; } }
        public int RunicMaxIntensity { get { return m_RunicMaxIntensity; } set { m_RunicMaxIntensity = value; } }

        public CraftAttributeInfo()
        {
        }

        public static readonly CraftAttributeInfo Blank;
        public static readonly CraftAttributeInfo DullCopper, ShadowIron, Copper, Bronze, Golden, Agapite, Verite, Valorite;
        public static readonly CraftAttributeInfo Spined, Horned, Barbed;
        public static readonly CraftAttributeInfo RedScales, YellowScales, BlackScales, GreenScales, WhiteScales, BlueScales;
        public static readonly CraftAttributeInfo OakWood, AshWood, YewWood, Heartwood, Bloodwood, Frostwood;

        static CraftAttributeInfo()
        {
            Blank = new CraftAttributeInfo();

            CraftAttributeInfo dullCopper = DullCopper = new CraftAttributeInfo();

            dullCopper.ArmorPhysicalResist = 2;
            dullCopper.ArmorFireResist = 1;
            dullCopper.ArmorColdResist = 1;
            dullCopper.ArmorPoisonResist = 1;
            dullCopper.ArmorEnergyResist = 1;
            dullCopper.WeaponLowerRequirements = 0;
            dullCopper.RunicMinAttributes = 1;
            dullCopper.RunicMaxAttributes = 2;
            DullCopper.WeaponDamageIncrease = 1;
            dullCopper.ArmorLuck = 10;
            dullCopper.WeaponLuck = 10;
            dullCopper.ArmorDurability = 10;
            dullCopper.WeaponDurability = 10;

            if (Core.ML)
            {
                dullCopper.RunicMinIntensity = 40;
                dullCopper.RunicMaxIntensity = 100;
            }
            else
            {
                dullCopper.RunicMinIntensity = 10;
                dullCopper.RunicMaxIntensity = 35;
            }

            CraftAttributeInfo shadowIron = ShadowIron = new CraftAttributeInfo();

            shadowIron.ArmorPhysicalResist = 3;
            shadowIron.ArmorFireResist = 1;
            shadowIron.ArmorColdResist = 1;
            shadowIron.ArmorPoisonResist = 1;
            shadowIron.ArmorEnergyResist = 5;
            shadowIron.WeaponLowerRequirements = 5;
            ShadowIron.WeaponDamageIncrease = 2;
            shadowIron.ArmorLuck = 15;
            shadowIron.WeaponLuck = 15;
            shadowIron.ArmorDurability = 15;
            shadowIron.WeaponDurability = 15;

            shadowIron.WeaponColdDamage = 20;

            shadowIron.RunicMinAttributes = 2;
            shadowIron.RunicMaxAttributes = 2;
            if (Core.ML)
            {
                shadowIron.RunicMinIntensity = 45;
                shadowIron.RunicMaxIntensity = 100;
            }
            else
            {
                shadowIron.RunicMinIntensity = 20;
                shadowIron.RunicMaxIntensity = 45;
            }

            CraftAttributeInfo copper = Copper = new CraftAttributeInfo();

            copper.ArmorPhysicalResist = 3;
            copper.ArmorFireResist = 5;
            copper.ArmorColdResist = 1;
            copper.ArmorPoisonResist = 1;
            copper.ArmorEnergyResist = 2;
            copper.WeaponPoisonDamage = 10;
            copper.WeaponEnergyDamage = 20;
            Copper.WeaponDamageIncrease = 3;
            copper.ArmorLuck = 20;
            copper.WeaponLuck = 20;
            copper.ArmorDurability = 20;
            copper.WeaponDurability = 20;

            copper.RunicMinAttributes = 2;
            copper.RunicMaxAttributes = 3;
            if (Core.ML)
            {
                copper.RunicMinIntensity = 50;
                copper.RunicMaxIntensity = 100;
            }
            else
            {
                copper.RunicMinIntensity = 25;
                copper.RunicMaxIntensity = 50;
            }

            CraftAttributeInfo bronze = Bronze = new CraftAttributeInfo();

            bronze.ArmorPhysicalResist = 4;
            bronze.ArmorFireResist = 2;
            bronze.ArmorColdResist = 1;
            bronze.ArmorPoisonResist = 5;
            bronze.ArmorEnergyResist = 2;
            bronze.WeaponPoisonDamage = 70;
            Bronze.WeaponDamageIncrease = 5;
            bronze.ArmorLuck = 25;
            bronze.WeaponLuck = 40;
            bronze.ArmorDurability = 25;
            bronze.WeaponDurability = 25;

            bronze.RunicMinAttributes = 3;
            bronze.RunicMaxAttributes = 3;
            if (Core.ML)
            {
                bronze.RunicMinIntensity = 55;
                bronze.RunicMaxIntensity = 100;
            }
            else
            {
                bronze.RunicMinIntensity = 30;
                bronze.RunicMaxIntensity = 65;
            }

            CraftAttributeInfo golden = Golden = new CraftAttributeInfo();

            golden.ArmorPhysicalResist = 6;
            golden.ArmorFireResist = 2;
            golden.ArmorColdResist = 2;
            golden.ArmorPoisonResist = 2;
            golden.ArmorEnergyResist = 3;
            golden.ArmorLowerRequirements = 30;
            golden.WeaponLowerRequirements = 50;
            Golden.WeaponDamageIncrease = 7;
            golden.ArmorLuck = 40;
            golden.WeaponLuck = 30;
            golden.ArmorDurability = 30;
            golden.WeaponDurability = 30;
            golden.RunicMinAttributes = 3;
            golden.RunicMaxAttributes = 4;
            if (Core.ML)
            {
                golden.RunicMinIntensity = 60;
                golden.RunicMaxIntensity = 100;
            }
            else
            {
                golden.RunicMinIntensity = 35;
                golden.RunicMaxIntensity = 75;
            }

            CraftAttributeInfo agapite = Agapite = new CraftAttributeInfo();

            agapite.ArmorPhysicalResist = 5;
            agapite.ArmorFireResist = 3;
            agapite.ArmorColdResist = 3;
            agapite.ArmorPoisonResist = 3;
            agapite.ArmorEnergyResist = 3;
            agapite.WeaponColdDamage = 30;
            agapite.WeaponEnergyDamage = 20;
            Agapite.WeaponDamageIncrease = 10;
            agapite.ArmorLuck = 45;
            agapite.WeaponLuck = 45;
            agapite.ArmorDurability = 35;
            agapite.WeaponDurability = 35;
            agapite.RunicMinAttributes = 4;
            agapite.RunicMaxAttributes = 4;
            if (Core.ML)
            {
                agapite.RunicMinIntensity = 65;
                agapite.RunicMaxIntensity = 100;
            }
            else
            {
                agapite.RunicMinIntensity = 40;
                agapite.RunicMaxIntensity = 80;
            }

            CraftAttributeInfo verite = Verite = new CraftAttributeInfo();

            verite.ArmorPhysicalResist = 5;
            verite.ArmorFireResist = 5;
            verite.ArmorColdResist = 3;
            verite.ArmorPoisonResist = 5;
            verite.ArmorEnergyResist = 3;
            verite.WeaponPoisonDamage = 40;
            verite.WeaponEnergyDamage = 40;
            Verite.WeaponDamageIncrease = 13;
            verite.ArmorLuck = 60;
            verite.WeaponLuck = 60;
            verite.ArmorDurability = 50;
            verite.WeaponDurability = 50;
            verite.RunicMinAttributes = 4;
            verite.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                verite.RunicMinIntensity = 70;
                verite.RunicMaxIntensity = 100;
            }
            else
            {
                verite.RunicMinIntensity = 45;
                verite.RunicMaxIntensity = 90;
            }

            CraftAttributeInfo valorite = Valorite = new CraftAttributeInfo();

            valorite.ArmorPhysicalResist = 6;
            valorite.ArmorFireResist = 4;
            valorite.ArmorColdResist = 4;
            valorite.ArmorPoisonResist = 4;
            valorite.ArmorEnergyResist = 4;
            valorite.ArmorDurability = 50;
            valorite.WeaponFireDamage = 80;
            Valorite.WeaponDamageIncrease = 16;
            valorite.ArmorLuck = 75;
            valorite.WeaponLuck = 75;
            valorite.ArmorDurability = 75;
            valorite.WeaponDurability = 75;
            valorite.RunicMinAttributes = 5;
            valorite.RunicMaxAttributes = 5;
            if (Core.ML)
            {
                valorite.RunicMinIntensity = 85;
                valorite.RunicMaxIntensity = 100;
            }
            else
            {
                valorite.RunicMinIntensity = 50;
                valorite.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo spined = Spined = new CraftAttributeInfo();

            spined.ArmorPhysicalResist = 3;
            spined.ArmorFireResist = 0;
            spined.ArmorColdResist = 0;
            spined.ArmorPoisonResist = 0;
            spined.ArmorEnergyResist = 0;
            spined.ArmorLuck = 40;
            spined.RunicMinAttributes = 1;
            spined.RunicMaxAttributes = 3;

            if (Core.ML)
            {
                spined.RunicMinIntensity = 40;
                spined.RunicMaxIntensity = 100;
            }
            else
            {
                spined.RunicMinIntensity = 20;
                spined.RunicMaxIntensity = 40;
            }

            CraftAttributeInfo horned = Horned = new CraftAttributeInfo();

            horned.ArmorPhysicalResist = 4;
            horned.ArmorFireResist = 3;
            horned.ArmorColdResist = 3;
            horned.ArmorPoisonResist = 3;
            horned.ArmorEnergyResist = 3;
            horned.ArmorLuck = 60;
            horned.RunicMinAttributes = 3;
            horned.RunicMaxAttributes = 4;
            if (Core.ML)
            {
                horned.RunicMinIntensity = 45;
                horned.RunicMaxIntensity = 100;
            }
            else
            {
                horned.RunicMinIntensity = 30;
                horned.RunicMaxIntensity = 70;
            }

            CraftAttributeInfo barbed = Barbed = new CraftAttributeInfo();

            barbed.ArmorPhysicalResist = 5;
            barbed.ArmorFireResist = 6;
            barbed.ArmorColdResist = 6;
            barbed.ArmorPoisonResist = 6;
            barbed.ArmorEnergyResist = 6;
            barbed.ArmorLuck = 80;
            barbed.RunicMinAttributes = 4;
            barbed.RunicMaxAttributes = 5;
            barbed.OtherSpellChanneling = 1;
            if (Core.ML)
            {
                barbed.RunicMinIntensity = 50;
                barbed.RunicMaxIntensity = 100;
            }
            else
            {
                barbed.RunicMinIntensity = 40;
                barbed.RunicMaxIntensity = 100;
            }

            CraftAttributeInfo red = RedScales = new CraftAttributeInfo();
            red.ArmorPhysicalResist = 4;
            red.ArmorFireResist = 11;
            red.ArmorColdResist = -3;
            red.ArmorPoisonResist = 2;
            red.ArmorEnergyResist = 2;
            red.ArmorLuck = 20;
            red.OtherSpellChanneling = 1;

            CraftAttributeInfo yellow = YellowScales = new CraftAttributeInfo();

            yellow.ArmorPhysicalResist = 4;
            yellow.ArmorFireResist = 2;
            yellow.ArmorColdResist = 2;
            yellow.ArmorPoisonResist = 2;
            yellow.ArmorPoisonResist = 2;
            yellow.ArmorLuck = 55;
            yellow.OtherSpellChanneling = 1;

            CraftAttributeInfo black = BlackScales = new CraftAttributeInfo();

            black.ArmorPhysicalResist = 9;
            black.ArmorEnergyResist = -3;
            black.ArmorFireResist = 2;
            black.ArmorPoisonResist = 2;
            black.ArmorColdResist = 2;
            black.ArmorLuck = 20;
            black.OtherSpellChanneling = 1;

            CraftAttributeInfo green = GreenScales = new CraftAttributeInfo();

            green.ArmorFireResist = -3;
            green.ArmorPhysicalResist = 4;
            green.ArmorColdResist = 2;
            green.ArmorEnergyResist = 2;
            green.ArmorPoisonResist = 11;
            green.ArmorLuck = 20;
            green.OtherSpellChanneling = 1;


            CraftAttributeInfo white = WhiteScales = new CraftAttributeInfo();

            white.ArmorPhysicalResist = 4;
            white.ArmorFireResist = 1;
            white.ArmorEnergyResist = 1;
            white.ArmorPoisonResist = 1;
            white.ArmorColdResist = 11;
            white.ArmorLuck = 20;
            white.OtherSpellChanneling = 1;

            CraftAttributeInfo blue = BlueScales = new CraftAttributeInfo();

            blue.ArmorPhysicalResist = 4;
            blue.ArmorFireResist = 2;
            blue.ArmorColdResist = 2;
            blue.ArmorPoisonResist = -3;
            blue.ArmorEnergyResist = 11;
            blue.ArmorLuck = 20;
            blue.OtherSpellChanneling = 1;

            #region Mondain's Legacy
            CraftAttributeInfo oak = OakWood = new CraftAttributeInfo();

            oak.ArmorPhysicalResist = 1;
            oak.ArmorFireResist = -5;
            oak.ArmorColdResist = 5;
            oak.ArmorPoisonResist = 2;
            oak.ArmorEnergyResist = 2;
            oak.ArmorLuck = 40;
            oak.WeaponLuck = 40;
            oak.WeaponDamageIncrease = 5;
            oak.WeaponSwingSpeed = 5;

            oak.ShieldPhysicalResist = 1;
            oak.ShieldFireResist = 1;
            oak.ShieldColdResist = 1;
            oak.ShieldPoisonResist = 1;
            oak.ShieldEnergyResist = 1;

            oak.RunicMinAttributes = 1;
            oak.RunicMaxAttributes = 2;
            oak.RunicMinIntensity = 1;
            oak.RunicMaxIntensity = 50;

            CraftAttributeInfo ash = AshWood = new CraftAttributeInfo();

            ash.ArmorPhysicalResist = 2;
            ash.ArmorFireResist = -5;
            ash.ArmorColdResist = 5;
            ash.ArmorPoisonResist = 3;
            ash.ArmorEnergyResist = 3;
            ash.ArmorLuck = 50;
            ash.WeaponLuck = 45;
            ash.WeaponDamage = 5;
            ash.WeaponSwingSpeed = 10;
            ash.ArmorLowerRequirements = 20;

            ash.ShieldEnergyResist = 3;
            ash.ShieldLowerRequirements = 3;

            ash.WeaponLowerRequirements = 20;

            ash.OtherLowerRequirements = 20;

            ash.RunicMinAttributes = 2;
            ash.RunicMaxAttributes = 3;
            ash.RunicMinIntensity = 35;
            ash.RunicMaxIntensity = 75;

            CraftAttributeInfo yew = YewWood = new CraftAttributeInfo();

            yew.ArmorPhysicalResist = 2;
            yew.ArmorFireResist = -5;
            yew.ArmorColdResist = 6;
            yew.ArmorPoisonResist = 4;
            yew.ArmorEnergyResist = 4;
            yew.ArmorLuck = 60;
            yew.WeaponLuck = 50;
            yew.WeaponDamage = 5;
            yew.WeaponSwingSpeed = 15;
            yew.ArmorLowerRequirements = 40;

            yew.ShieldPhysicalResist = 3;
            yew.ShieldRegenHits = 1;

            yew.WeaponHitChance = 5;

            yew.OtherRegenHits = 2;

            yew.RunicMinAttributes = 3;
            yew.RunicMaxAttributes = 3;
            yew.RunicMinIntensity = 40;
            yew.RunicMaxIntensity = 90;

            CraftAttributeInfo heartwood = Heartwood = new CraftAttributeInfo();

            heartwood.ArmorPhysicalResist = 3;
            heartwood.ArmorFireResist = -5;
            heartwood.ArmorColdResist = 6;
            heartwood.ArmorPoisonResist = 6;
            heartwood.ArmorEnergyResist = 4;
            heartwood.ArmorLuck = 70;
            heartwood.WeaponLuck = 55;
            heartwood.WeaponDamage = 7;
            heartwood.WeaponSwingSpeed = 15;
            heartwood.ArmorLowerRequirements = 50;

            // one of below
            /*heartwood.ArmorDamage = 10;
            heartwood.ArmorHitChance = 5;
            heartwood.ArmorLuck = 40;
            heartwood.ArmorLowerRequirements = 20;
            heartwood.ArmorMage = 1;

            // one of below
            heartwood.WeaponDamage = 10;
            heartwood.WeaponHitChance = 5;
            heartwood.WeaponHitLifeLeech = 13;
            heartwood.WeaponLuck = 40;
            heartwood.WeaponLowerRequirements = 20;
            heartwood.WeaponSwingSpeed = 10;*/

            heartwood.ShieldBonusDex = 2;
            heartwood.ShieldBonusStr = 2;
            heartwood.ShieldPhysicalRandom = 5;
            heartwood.ShieldReflectPhys = 5;
            heartwood.ShieldSelfRepair = 2;
            heartwood.ShieldColdRandom = 3;
            heartwood.ShieldSpellChanneling = 1;

            heartwood.RunicMinAttributes = 4;
            heartwood.RunicMaxAttributes = 4;
            heartwood.RunicMinIntensity = 50;
            heartwood.RunicMaxIntensity = 100;

            CraftAttributeInfo bloodwood = Bloodwood = new CraftAttributeInfo();

            bloodwood.ArmorPhysicalResist = 4;
            bloodwood.ArmorFireResist = -5;
            bloodwood.ArmorColdResist = 6;
            bloodwood.ArmorPoisonResist = 6;
            bloodwood.ArmorEnergyResist = 6;
            bloodwood.ArmorLuck = 80;
            bloodwood.WeaponLuck = 60;
            bloodwood.WeaponDamage = 7;
            bloodwood.WeaponSwingSpeed = 20;
            bloodwood.ArmorLowerRequirements = 60;

            bloodwood.ShieldFireResist = 3;
            bloodwood.ShieldLuck = 40;
            bloodwood.ShieldRegenHits = 2;

            bloodwood.WeaponRegenHits = 3;
            bloodwood.WeaponHitLifeLeech = 16;

            bloodwood.OtherLuck = 20;
            bloodwood.OtherRegenHits = 3;

            bloodwood.WeaponFireDamage = 50;

            CraftAttributeInfo frostwood = Frostwood = new CraftAttributeInfo();

            frostwood.ArmorPhysicalResist = 4;
            frostwood.ArmorFireResist = -5;
            frostwood.ArmorColdResist = 8;
            frostwood.ArmorPoisonResist = 8;
            frostwood.ArmorEnergyResist = 8;
            frostwood.ArmorLuck = 90;
            frostwood.WeaponLuck = 65;
            frostwood.WeaponDamage = 10;
            frostwood.WeaponSwingSpeed = 25;
            frostwood.ArmorLowerRequirements = 60;

            frostwood.ShieldColdResist = 3;
            frostwood.ShieldSpellChanneling = 1;

            frostwood.WeaponColdDamage = 50;

            Frostwood.OtherSpellChanneling = 1;
            #endregion
        }
    }

    public class CraftResourceInfo
    {
        private readonly int m_Hue;
        private readonly int m_Number;
        private readonly string m_Name;
        private readonly CraftAttributeInfo m_AttributeInfo;
        private readonly CraftResource m_Resource;
        private readonly Type[] m_ResourceTypes;

        public int Hue
        {
            get
            {
                return this.m_Hue;
            }
        }
        public int Number
        {
            get
            {
                return this.m_Number;
            }
        }
        public string Name
        {
            get
            {
                return this.m_Name;
            }
        }
        public CraftAttributeInfo AttributeInfo
        {
            get
            {
                return this.m_AttributeInfo;
            }
        }
        public CraftResource Resource
        {
            get
            {
                return this.m_Resource;
            }
        }
        public Type[] ResourceTypes
        {
            get
            {
                return this.m_ResourceTypes;
            }
        }

        public CraftResourceInfo(int hue, int number, string name, CraftAttributeInfo attributeInfo, CraftResource resource, params Type[] resourceTypes)
        {
            this.m_Hue = hue;
            this.m_Number = number;
            this.m_Name = name;
            this.m_AttributeInfo = attributeInfo;
            this.m_Resource = resource;
            this.m_ResourceTypes = resourceTypes;

            for (int i = 0; i < resourceTypes.Length; ++i)
                CraftResources.RegisterType(resourceTypes[i], resource);
        }
    }

    public class CraftResources
    {
        private static readonly CraftResourceInfo[] m_MetalInfo = new CraftResourceInfo[]
        {
            new CraftResourceInfo(0x000, 1053109, "Iron", CraftAttributeInfo.Blank, CraftResource.Iron, typeof(IronIngot), typeof(IronOre), typeof(Granite)),
            new CraftResourceInfo(0x96D, 1053108, "Dull Copper",	CraftAttributeInfo.DullCopper,	CraftResource.DullCopper, typeof(DullCopperIngot),	typeof(DullCopperOre),	typeof(DullCopperGranite)),
            new CraftResourceInfo(0x8DE, 1053107, "Shadow Iron",	CraftAttributeInfo.ShadowIron,	CraftResource.ShadowIron, typeof(ShadowIronIngot),	typeof(ShadowIronOre),	typeof(ShadowIronGranite)),
            new CraftResourceInfo(0x7BA, 1053106, "Copper", CraftAttributeInfo.Copper, CraftResource.Copper, typeof(CopperIngot), typeof(CopperOre), typeof(CopperGranite)),
            new CraftResourceInfo(0x98C, 1053105, "Bronze", CraftAttributeInfo.Bronze, CraftResource.Bronze, typeof(BronzeIngot), typeof(BronzeOre), typeof(BronzeGranite)),
            new CraftResourceInfo(0x95E, 1053104, "Gold", CraftAttributeInfo.Golden, CraftResource.Gold, typeof(GoldIngot), typeof(GoldOre), typeof(GoldGranite)),
            new CraftResourceInfo(0x99B, 1053103, "Agapite", CraftAttributeInfo.Agapite, CraftResource.Agapite, typeof(AgapiteIngot), typeof(AgapiteOre), typeof(AgapiteGranite)),
            new CraftResourceInfo(0x910, 1053102, "Verite", CraftAttributeInfo.Verite, CraftResource.Verite, typeof(VeriteIngot), typeof(VeriteOre), typeof(VeriteGranite)),
            new CraftResourceInfo(0xAC7, 1053101, "Valorite", CraftAttributeInfo.Valorite,	CraftResource.Valorite, typeof(ValoriteIngot),	typeof(ValoriteOre), typeof(ValoriteGranite)),
        };

        private static readonly CraftResourceInfo[] m_ScaleInfo = new CraftResourceInfo[]
        {
            new CraftResourceInfo(0x66D, 1053129, "Red Scales",	CraftAttributeInfo.RedScales, CraftResource.RedScales, typeof(RedScales)),
            new CraftResourceInfo(0x8A8, 1053130, "Yellow Scales",	CraftAttributeInfo.YellowScales,	CraftResource.YellowScales, typeof(YellowScales)),
            new CraftResourceInfo(0x455, 1053131, "Black Scales",	CraftAttributeInfo.BlackScales, CraftResource.BlackScales, typeof(BlackScales)),
            new CraftResourceInfo(0x851, 1053132, "Green Scales",	CraftAttributeInfo.GreenScales, CraftResource.GreenScales, typeof(GreenScales)),
            new CraftResourceInfo(0x8FD, 1053133, "White Scales",	CraftAttributeInfo.WhiteScales, CraftResource.WhiteScales, typeof(WhiteScales)),
            new CraftResourceInfo(0x8B0, 1053134, "Blue Scales",	CraftAttributeInfo.BlueScales, CraftResource.BlueScales, typeof(BlueScales))
        };

        private static readonly CraftResourceInfo[] m_LeatherInfo = new CraftResourceInfo[]
        {
            new CraftResourceInfo(0x000, 1049353, "Normal", CraftAttributeInfo.Blank, CraftResource.RegularLeather,	typeof(Leather), typeof(Hides)),
            new CraftResourceInfo(0x283, 1049354, "Spined", CraftAttributeInfo.Spined, CraftResource.SpinedLeather,	typeof(SpinedLeather),	typeof(SpinedHides)),
            new CraftResourceInfo(0x227, 1049355, "Horned", CraftAttributeInfo.Horned, CraftResource.HornedLeather,	typeof(HornedLeather),	typeof(HornedHides)),
            new CraftResourceInfo(0x1C1, 1049356, "Barbed", CraftAttributeInfo.Barbed, CraftResource.BarbedLeather,	typeof(BarbedLeather),	typeof(BarbedHides))
        };

        private static readonly CraftResourceInfo[] m_AOSLeatherInfo = new CraftResourceInfo[]
        {
            new CraftResourceInfo(0x000, 1049353, "Normal", CraftAttributeInfo.Blank, CraftResource.RegularLeather,	typeof(Leather), typeof(Hides)),
            new CraftResourceInfo(0x8AC, 1049354, "Spined", CraftAttributeInfo.Spined, CraftResource.SpinedLeather,	typeof(SpinedLeather),	typeof(SpinedHides)),
            new CraftResourceInfo(0x845, 1049355, "Horned", CraftAttributeInfo.Horned, CraftResource.HornedLeather,	typeof(HornedLeather),	typeof(HornedHides)),
            new CraftResourceInfo(0x851, 1049356, "Barbed", CraftAttributeInfo.Barbed, CraftResource.BarbedLeather,	typeof(BarbedLeather),	typeof(BarbedHides)),
        };

        private static readonly CraftResourceInfo[] m_WoodInfo = new CraftResourceInfo[]
        {
            new CraftResourceInfo(0x000, 1011542, "Normal", CraftAttributeInfo.Blank, CraftResource.RegularWood,	typeof(Log), typeof(Board)),
            new CraftResourceInfo(0x7DA, 1072533, "Oak", CraftAttributeInfo.OakWood, CraftResource.OakWood, typeof(OakLog), typeof(OakBoard)),
            new CraftResourceInfo(0x4A7, 1072534, "Ash", CraftAttributeInfo.AshWood, CraftResource.AshWood, typeof(AshLog), typeof(AshBoard)),
            new CraftResourceInfo(0x4A8, 1072535, "Yew", CraftAttributeInfo.YewWood, CraftResource.YewWood, typeof(YewLog), typeof(YewBoard)),
            new CraftResourceInfo(0x4A9, 1072536, "Heartwood", CraftAttributeInfo.Heartwood,	CraftResource.Heartwood,	typeof(HeartwoodLog),	typeof(HeartwoodBoard)),
            new CraftResourceInfo(0x4AA, 1072538, "Bloodwood", CraftAttributeInfo.Bloodwood,	CraftResource.Bloodwood,	typeof(BloodwoodLog),	typeof(BloodwoodBoard)),
            new CraftResourceInfo(0x47F, 1072539, "Frostwood", CraftAttributeInfo.Frostwood,	CraftResource.Frostwood,	typeof(FrostwoodLog),	typeof(FrostwoodBoard))
        };

        /// <summary>
        /// Returns true if '<paramref name="resource"/>' is None, Iron, RegularLeather or RegularWood. False if otherwise.
        /// </summary>
        public static bool IsStandard(CraftResource resource)
        {
            return (resource == CraftResource.None || resource == CraftResource.Iron || resource == CraftResource.RegularLeather || resource == CraftResource.RegularWood);
        }

        private static Hashtable m_TypeTable;

        /// <summary>
        /// Registers that '<paramref name="resourceType"/>' uses '<paramref name="resource"/>' so that it can later be queried by <see cref="CraftResources.GetFromType"/>
        /// </summary>
        public static void RegisterType(Type resourceType, CraftResource resource)
        {
            if (m_TypeTable == null)
                m_TypeTable = new Hashtable();

            m_TypeTable[resourceType] = resource;
        }

        /// <summary>
        /// Returns the <see cref="CraftResource"/> value for which '<paramref name="resourceType"/>' uses -or- CraftResource.None if an unregistered type was specified.
        /// </summary>
        public static CraftResource GetFromType(Type resourceType)
        {
            if (m_TypeTable == null)
                return CraftResource.None;

            object obj = m_TypeTable[resourceType];

            if (!(obj is CraftResource))
                return CraftResource.None;

            return (CraftResource)obj;
        }

        /// <summary>
        /// Returns a <see cref="CraftResourceInfo"/> instance describing '<paramref name="resource"/>' -or- null if an invalid resource was specified.
        /// </summary>
        public static CraftResourceInfo GetInfo(CraftResource resource)
        {
            CraftResourceInfo[] list = null;

            switch (GetType(resource))
            {
                case CraftResourceType.Metal:
                    list = m_MetalInfo;
                    break;
                case CraftResourceType.Leather:
                    list = Core.AOS ? m_AOSLeatherInfo : m_LeatherInfo;
                    break;
                case CraftResourceType.Scales:
                    list = m_ScaleInfo;
                    break;
                case CraftResourceType.Wood:
                    list = m_WoodInfo;
                    break;
            }

            if (list != null)
            {
                int index = GetIndex(resource);

                if (index >= 0 && index < list.Length)
                    return list[index];
            }

            return null;
        }

        /// <summary>
        /// Returns a <see cref="CraftResourceType"/> value indiciating the type of '<paramref name="resource"/>'.
        /// </summary>
        public static CraftResourceType GetType(CraftResource resource)
        {
            if (resource >= CraftResource.Iron && resource <= CraftResource.Valorite)
                return CraftResourceType.Metal;

            if (resource >= CraftResource.RegularLeather && resource <= CraftResource.BarbedLeather)
                return CraftResourceType.Leather;

            if (resource >= CraftResource.RedScales && resource <= CraftResource.BlueScales)
                return CraftResourceType.Scales;

            if (resource >= CraftResource.RegularWood && resource <= CraftResource.Frostwood)
                return CraftResourceType.Wood;

            return CraftResourceType.None;
        }

        /// <summary>
        /// Returns the first <see cref="CraftResource"/> in the series of resources for which '<paramref name="resource"/>' belongs.
        /// </summary>
        public static CraftResource GetStart(CraftResource resource)
        {
            switch (GetType(resource))
            {
                case CraftResourceType.Metal:
                    return CraftResource.Iron;
                case CraftResourceType.Leather:
                    return CraftResource.RegularLeather;
                case CraftResourceType.Scales:
                    return CraftResource.RedScales;
                case CraftResourceType.Wood:
                    return CraftResource.RegularWood;
            }

            return CraftResource.None;
        }

        /// <summary>
        /// Returns the index of '<paramref name="resource"/>' in the seriest of resources for which it belongs.
        /// </summary>
        public static int GetIndex(CraftResource resource)
        {
            CraftResource start = GetStart(resource);

            if (start == CraftResource.None)
                return 0;

            return (int)(resource - start);
        }

        /// <summary>
        /// Returns the <see cref="CraftResourceInfo.Number"/> property of '<paramref name="resource"/>' -or- 0 if an invalid resource was specified.
        /// </summary>
        public static int GetLocalizationNumber(CraftResource resource)
        {
            CraftResourceInfo info = GetInfo(resource);

            return (info == null ? 0 : info.Number);
        }

        /// <summary>
        /// Returns the <see cref="CraftResourceInfo.Hue"/> property of '<paramref name="resource"/>' -or- 0 if an invalid resource was specified.
        /// </summary>
        public static int GetHue(CraftResource resource)
        {
            CraftResourceInfo info = GetInfo(resource);

            return (info == null ? 0 : info.Hue);
        }

        /// <summary>
        /// Returns the <see cref="CraftResourceInfo.Name"/> property of '<paramref name="resource"/>' -or- an empty string if the resource specified was invalid.
        /// </summary>
        public static string GetName(CraftResource resource)
        {
            CraftResourceInfo info = GetInfo(resource);

            return (info == null ? String.Empty : info.Name);
        }

        /// <summary>
        /// Returns the <see cref="CraftResource"/> value which represents '<paramref name="info"/>' -or- CraftResource.None if unable to convert.
        /// </summary>
        public static CraftResource GetFromOreInfo(OreInfo info)
        {
            if (info.Name.IndexOf("Spined") >= 0)
                return CraftResource.SpinedLeather;
            else if (info.Name.IndexOf("Horned") >= 0)
                return CraftResource.HornedLeather;
            else if (info.Name.IndexOf("Barbed") >= 0)
                return CraftResource.BarbedLeather;
            else if (info.Name.IndexOf("Leather") >= 0)
                return CraftResource.RegularLeather;

            if (info.Level == 0)
                return CraftResource.Iron;
            else if (info.Level == 1)
                return CraftResource.DullCopper;
            else if (info.Level == 2)
                return CraftResource.ShadowIron;
            else if (info.Level == 3)
                return CraftResource.Copper;
            else if (info.Level == 4)
                return CraftResource.Bronze;
            else if (info.Level == 5)
                return CraftResource.Gold;
            else if (info.Level == 6)
                return CraftResource.Agapite;
            else if (info.Level == 7)
                return CraftResource.Verite;
            else if (info.Level == 8)
                return CraftResource.Valorite;

            return CraftResource.None;
        }

        /// <summary>
        /// Returns the <see cref="CraftResource"/> value which represents '<paramref name="info"/>', using '<paramref name="material"/>' to help resolve leather OreInfo instances.
        /// </summary>
        public static CraftResource GetFromOreInfo(OreInfo info, ArmorMaterialType material)
        {
            if (material == ArmorMaterialType.Studded || material == ArmorMaterialType.Leather || material == ArmorMaterialType.Spined ||
                material == ArmorMaterialType.Horned || material == ArmorMaterialType.Barbed)
            {
                if (info.Level == 0)
                    return CraftResource.RegularLeather;
                else if (info.Level == 1)
                    return CraftResource.SpinedLeather;
                else if (info.Level == 2)
                    return CraftResource.HornedLeather;
                else if (info.Level == 3)
                    return CraftResource.BarbedLeather;

                return CraftResource.None;
            }

            return GetFromOreInfo(info);
        }
    }

    // NOTE: This class is only for compatability with very old RunUO versions.
    // No changes to it should be required for custom resources.
    public class OreInfo
    {
        public static readonly OreInfo Iron = new OreInfo(0, 0x000, "Iron");
        public static readonly OreInfo DullCopper = new OreInfo(1, 0x973, "Dull Copper");
        public static readonly OreInfo ShadowIron = new OreInfo(2, 0x966, "Shadow Iron");
        public static readonly OreInfo Copper = new OreInfo(3, 0x96D, "Copper");
        public static readonly OreInfo Bronze = new OreInfo(4, 0x972, "Bronze");
        public static readonly OreInfo Gold = new OreInfo(5, 0x8A5, "Gold");
        public static readonly OreInfo Agapite = new OreInfo(6, 0x979, "Agapite");
        public static readonly OreInfo Verite = new OreInfo(7, 0x89F, "Verite");
        public static readonly OreInfo Valorite = new OreInfo(8, 0x8AB, "Valorite");

        private readonly int m_Level;
        private readonly int m_Hue;
        private readonly string m_Name;

        public OreInfo(int level, int hue, string name)
        {
            this.m_Level = level;
            this.m_Hue = hue;
            this.m_Name = name;
        }

        public int Level
        {
            get
            {
                return this.m_Level;
            }
        }

        public int Hue
        {
            get
            {
                return this.m_Hue;
            }
        }

        public string Name
        {
            get
            {
                return this.m_Name;
            }
        }
    }
}