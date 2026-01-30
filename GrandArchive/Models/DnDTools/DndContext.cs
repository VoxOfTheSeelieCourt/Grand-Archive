using System.IO;
using GrandArchive.Helpers;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace GrandArchive.Models.DnDTools;

public partial class DndContext : DbContext
{
    public virtual DbSet<DndCharacterclass> DndCharacterclasses { get; set; }

    public virtual DbSet<DndCharacterclassvariant> DndCharacterclassvariants { get; set; }

    public virtual DbSet<DndCharacterclassvariantClassSkill> DndCharacterclassvariantClassSkills { get; set; }

    public virtual DbSet<DndCharacterclassvariantrequiresfeat> DndCharacterclassvariantrequiresfeats { get; set; }

    public virtual DbSet<DndCharacterclassvariantrequiresrace> DndCharacterclassvariantrequiresraces { get; set; }

    public virtual DbSet<DndCharacterclassvariantrequiresskill> DndCharacterclassvariantrequiresskills { get; set; }

    public virtual DbSet<DndDeity> DndDeities { get; set; }

    public virtual DbSet<DndDndedition> DndDndeditions { get; set; }

    public virtual DbSet<DndDomain> DndDomains { get; set; }

    public virtual DbSet<DndDomainvariant> DndDomainvariants { get; set; }

    public virtual DbSet<DndDomainvariantDeity> DndDomainvariantDeities { get; set; }

    public virtual DbSet<DndDomainvariantOtherDeity> DndDomainvariantOtherDeities { get; set; }

    public virtual DbSet<DndFeat> DndFeats { get; set; }

    public virtual DbSet<DndFeatFeatCategory> DndFeatFeatCategories { get; set; }

    public virtual DbSet<DndFeatcategory> DndFeatcategories { get; set; }

    public virtual DbSet<DndFeatrequiresfeat> DndFeatrequiresfeats { get; set; }

    public virtual DbSet<DndFeatrequiresskill> DndFeatrequiresskills { get; set; }

    public virtual DbSet<DndFeatspecialfeatprerequisite> DndFeatspecialfeatprerequisites { get; set; }

    public virtual DbSet<DndItem> DndItems { get; set; }

    public virtual DbSet<DndItemAuraSchool> DndItemAuraSchools { get; set; }

    public virtual DbSet<DndItemRequiredFeat> DndItemRequiredFeats { get; set; }

    public virtual DbSet<DndItemRequiredSpell> DndItemRequiredSpells { get; set; }

    public virtual DbSet<DndItemactivationtype> DndItemactivationtypes { get; set; }

    public virtual DbSet<DndItemauratype> DndItemauratypes { get; set; }

    public virtual DbSet<DndItemproperty> DndItemproperties { get; set; }

    public virtual DbSet<DndItemslot> DndItemslots { get; set; }

    public virtual DbSet<DndLanguage> DndLanguages { get; set; }

    public virtual DbSet<DndMonster> DndMonsters { get; set; }

    public virtual DbSet<DndMonsterSubtype> DndMonsterSubtypes { get; set; }

    public virtual DbSet<DndMonsterhasfeat> DndMonsterhasfeats { get; set; }

    public virtual DbSet<DndMonsterhasskill> DndMonsterhasskills { get; set; }

    public virtual DbSet<DndMonsterspeed> DndMonsterspeeds { get; set; }

    public virtual DbSet<DndMonstersubtype1> DndMonstersubtypes1 { get; set; }

    public virtual DbSet<DndMonstertype> DndMonstertypes { get; set; }

    public virtual DbSet<DndNewsentry> DndNewsentries { get; set; }

    public virtual DbSet<DndRace> DndRaces { get; set; }

    public virtual DbSet<DndRaceAutomaticLanguage> DndRaceAutomaticLanguages { get; set; }

    public virtual DbSet<DndRaceBonusLanguage> DndRaceBonusLanguages { get; set; }

    public virtual DbSet<DndRacefavoredcharacterclass> DndRacefavoredcharacterclasses { get; set; }

    public virtual DbSet<DndRacesize> DndRacesizes { get; set; }

    public virtual DbSet<DndRacespeed> DndRacespeeds { get; set; }

    public virtual DbSet<DndRacespeedtype> DndRacespeedtypes { get; set; }

    public virtual DbSet<DndRacetype> DndRacetypes { get; set; }

    public virtual DbSet<DndRule> DndRules { get; set; }

    public virtual DbSet<DndRulebook> DndRulebooks { get; set; }

    public virtual DbSet<DndRulesCondition> DndRulesConditions { get; set; }

    public virtual DbSet<DndSkill> DndSkills { get; set; }

    public virtual DbSet<DndSkillvariant> DndSkillvariants { get; set; }

    public virtual DbSet<DndSpecialfeatprerequisite> DndSpecialfeatprerequisites { get; set; }

    public virtual DbSet<DndSpell> DndSpells { get; set; }

    public virtual DbSet<DndSpellDescriptor> DndSpellDescriptors { get; set; }

    public virtual DbSet<DndSpellclasslevel> DndSpellclasslevels { get; set; }

    public virtual DbSet<DndSpelldescriptor1> DndSpelldescriptors1 { get; set; }

    public virtual DbSet<DndSpelldomainlevel> DndSpelldomainlevels { get; set; }

    public virtual DbSet<DndSpellschool> DndSpellschools { get; set; }

    public virtual DbSet<DndSpellsubschool> DndSpellsubschools { get; set; }

    public virtual DbSet<DndStaticpage> DndStaticpages { get; set; }

    public virtual DbSet<DndTextfeatprerequisite> DndTextfeatprerequisites { get; set; }

    public DndContext(DbContextOptions<DndContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DndCharacterclass>(entity =>
        {
            entity.ToTable("dnd_characterclass");

            entity.HasIndex(e => e.Slug, "dnd_characterclass_dnd_characterclass_a951d5d6");

            entity.HasIndex(e => e.Name, "dnd_characterclass_dnd_characterclass_name");

            entity.HasIndex(e => e.Slug, "dnd_characterclass_dnd_characterclass_slug_uniq");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("name");
            entity.Property(e => e.Prestige)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(1)")
                .HasColumnName("prestige");
            entity.Property(e => e.ShortDescription)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("short_description");
            entity.Property(e => e.ShortDescriptionHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("short_description_html");
            entity.Property(e => e.Slug)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("slug");
        });

        modelBuilder.Entity<DndCharacterclassvariant>(entity =>
        {
            entity.ToTable("dnd_characterclassvariant");

            entity.HasIndex(e => e.CharacterClassId, "dnd_characterclassvariant_dnd_characterclassvariant_4d1287f7");

            entity.HasIndex(e => e.RulebookId, "dnd_characterclassvariant_dnd_characterclassvariant_51956a35");

            entity.HasIndex(e => new { e.RulebookId, e.CharacterClassId }, "dnd_characterclassvariant_dnd_characterclassvariant_rulebook_id_69a6fb11587c030e_uniq");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Advancement)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("advancement");
            entity.Property(e => e.AdvancementHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("advancement_html");
            entity.Property(e => e.Alignment)
                .IsRequired()
                .HasColumnType("varchar(256)")
                .HasColumnName("alignment");
            entity.Property(e => e.CharacterClassId)
                .HasColumnType("int(11)")
                .HasColumnName("character_class_id");
            entity.Property(e => e.ClassFeatures)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("class_features");
            entity.Property(e => e.ClassFeaturesHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("class_features_html");
            entity.Property(e => e.HitDie)
                .HasDefaultValueSql("NULL")
                .HasColumnType("smallint(5)")
                .HasColumnName("hit_die");
            entity.Property(e => e.Page)
                .HasDefaultValueSql("NULL")
                .HasColumnType("smallint(5)")
                .HasColumnName("page");
            entity.Property(e => e.RequiredBab)
                .HasDefaultValueSql("NULL")
                .HasColumnType("smallint(5)")
                .HasColumnName("required_bab");
            entity.Property(e => e.Requirements)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("requirements");
            entity.Property(e => e.RequirementsHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("requirements_html");
            entity.Property(e => e.RulebookId)
                .HasColumnType("int(11)")
                .HasColumnName("rulebook_id");
            entity.Property(e => e.SkillPoints)
                .HasDefaultValueSql("NULL")
                .HasColumnType("smallint(5)")
                .HasColumnName("skill_points");
            entity.Property(e => e.StartingGold)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("starting_gold");

            entity.HasOne(d => d.CharacterClass).WithMany(p => p.DndCharacterclassvariants)
                .HasForeignKey(d => d.CharacterClassId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Rulebook).WithMany(p => p.DndCharacterclassvariants)
                .HasForeignKey(d => d.RulebookId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndCharacterclassvariantClassSkill>(entity =>
        {
            entity.ToTable("dnd_characterclassvariant_class_skills");

            entity.HasIndex(e => new { e.CharacterclassvariantId, e.SkillId }, "dnd_characterclassvariant_class_skills_dnd_charactercla_characterclassvariant_id_594218372f051506_uniq");

            entity.HasIndex(e => e.SkillId, "dnd_characterclassvariant_class_skills_dnd_characterclassvariant_class_skills_30f70346");

            entity.HasIndex(e => e.CharacterclassvariantId, "dnd_characterclassvariant_class_skills_dnd_characterclassvariant_class_skills_62519975");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CharacterclassvariantId)
                .HasColumnType("int(11)")
                .HasColumnName("characterclassvariant_id");
            entity.Property(e => e.SkillId)
                .HasColumnType("int(11)")
                .HasColumnName("skill_id");

            entity.HasOne(d => d.Characterclassvariant).WithMany(p => p.DndCharacterclassvariantClassSkills)
                .HasForeignKey(d => d.CharacterclassvariantId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Skill).WithMany(p => p.DndCharacterclassvariantClassSkills)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndCharacterclassvariantrequiresfeat>(entity =>
        {
            entity.ToTable("dnd_characterclassvariantrequiresfeat");

            entity.HasIndex(e => e.FeatId, "dnd_characterclassvariantrequiresfeat_dnd_characterclassvariantrequiresfeat_2f59e7d8");

            entity.HasIndex(e => e.CharacterClassVariantId, "dnd_characterclassvariantrequiresfeat_dnd_characterclassvariantrequiresfeat_433a4f0b");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CharacterClassVariantId)
                .HasColumnType("int(11)")
                .HasColumnName("character_class_variant_id");
            entity.Property(e => e.Extra)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("extra");
            entity.Property(e => e.FeatId)
                .HasColumnType("int(11)")
                .HasColumnName("feat_id");
            entity.Property(e => e.RemoveComma)
                .HasColumnType("tinyint(1)")
                .HasColumnName("remove_comma");
            entity.Property(e => e.TextAfter)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("text_after");
            entity.Property(e => e.TextBefore)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("text_before");

            entity.HasOne(d => d.CharacterClassVariant).WithMany(p => p.DndCharacterclassvariantrequiresfeats)
                .HasForeignKey(d => d.CharacterClassVariantId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Feat).WithMany(p => p.DndCharacterclassvariantrequiresfeats)
                .HasForeignKey(d => d.FeatId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndCharacterclassvariantrequiresrace>(entity =>
        {
            entity.ToTable("dnd_characterclassvariantrequiresrace");

            entity.HasIndex(e => e.RaceId, "dnd_characterclassvariantrequiresrace_dnd_characterclassvariantrequiresrace_3548c065");

            entity.HasIndex(e => e.CharacterClassVariantId, "dnd_characterclassvariantrequiresrace_dnd_characterclassvariantrequiresrace_433a4f0b");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CharacterClassVariantId)
                .HasColumnType("int(11)")
                .HasColumnName("character_class_variant_id");
            entity.Property(e => e.Extra)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("extra");
            entity.Property(e => e.RaceId)
                .HasColumnType("int(11)")
                .HasColumnName("race_id");
            entity.Property(e => e.RemoveComma)
                .HasColumnType("tinyint(1)")
                .HasColumnName("remove_comma");
            entity.Property(e => e.TextAfter)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("text_after");
            entity.Property(e => e.TextBefore)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("text_before");

            entity.HasOne(d => d.CharacterClassVariant).WithMany(p => p.DndCharacterclassvariantrequiresraces)
                .HasForeignKey(d => d.CharacterClassVariantId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Race).WithMany(p => p.DndCharacterclassvariantrequiresraces)
                .HasForeignKey(d => d.RaceId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndCharacterclassvariantrequiresskill>(entity =>
        {
            entity.ToTable("dnd_characterclassvariantrequiresskill");

            entity.HasIndex(e => e.SkillId, "dnd_characterclassvariantrequiresskill_dnd_characterclassvariantrequiresskill_30f70346");

            entity.HasIndex(e => e.CharacterClassVariantId, "dnd_characterclassvariantrequiresskill_dnd_characterclassvariantrequiresskill_433a4f0b");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CharacterClassVariantId)
                .HasColumnType("int(11)")
                .HasColumnName("character_class_variant_id");
            entity.Property(e => e.Extra)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("extra");
            entity.Property(e => e.Ranks)
                .HasColumnType("smallint(5)")
                .HasColumnName("ranks");
            entity.Property(e => e.RemoveComma)
                .HasColumnType("tinyint(1)")
                .HasColumnName("remove_comma");
            entity.Property(e => e.SkillId)
                .HasColumnType("int(11)")
                .HasColumnName("skill_id");
            entity.Property(e => e.TextAfter)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("text_after");
            entity.Property(e => e.TextBefore)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("text_before");

            entity.HasOne(d => d.CharacterClassVariant).WithMany(p => p.DndCharacterclassvariantrequiresskills)
                .HasForeignKey(d => d.CharacterClassVariantId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Skill).WithMany(p => p.DndCharacterclassvariantrequiresskills)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndDeity>(entity =>
        {
            entity.ToTable("dnd_deity");

            entity.HasIndex(e => e.FavoredWeaponId, "dnd_deity_dnd_deity_42d3ba94");

            entity.HasIndex(e => e.Name, "dnd_deity_name");

            entity.HasIndex(e => e.Slug, "dnd_deity_slug");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Alignment)
                .IsRequired()
                .HasColumnType("varchar(2)")
                .HasColumnName("alignment");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("description");
            entity.Property(e => e.DescriptionHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("description_html");
            entity.Property(e => e.FavoredWeaponId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("int(11)")
                .HasColumnName("favored_weapon_id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("name");
            entity.Property(e => e.Slug)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("slug");

            entity.HasOne(d => d.FavoredWeapon).WithMany(p => p.DndDeities).HasForeignKey(d => d.FavoredWeaponId);
        });

        modelBuilder.Entity<DndDndedition>(entity =>
        {
            entity.ToTable("dnd_dndedition");

            entity.HasIndex(e => e.Slug, "dnd_dndedition_dnd_dndedition_a951d5d6");

            entity.HasIndex(e => e.Name, "dnd_dndedition_dnd_dndedition_name");

            entity.HasIndex(e => e.Slug, "dnd_dndedition_dnd_dndedition_slug_uniq");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Core)
                .HasColumnType("tinyint(1)")
                .HasColumnName("core");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("name");
            entity.Property(e => e.Slug)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("slug");
            entity.Property(e => e.System)
                .IsRequired()
                .HasColumnType("varchar(16)")
                .HasColumnName("system");
        });

        modelBuilder.Entity<DndDomain>(entity =>
        {
            entity.ToTable("dnd_domain");

            entity.HasIndex(e => e.Slug, "dnd_domain_dnd_domain_a951d5d6");

            entity.HasIndex(e => e.Name, "dnd_domain_dnd_domain_name_uniq");

            entity.HasIndex(e => e.Slug, "dnd_domain_dnd_domain_slug_uniq");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("name");
            entity.Property(e => e.Slug)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("slug");
        });

        modelBuilder.Entity<DndDomainvariant>(entity =>
        {
            entity.ToTable("dnd_domainvariant");

            entity.HasIndex(e => e.RulebookId, "dnd_domainvariant_dnd_domainvariant_51956a35");

            entity.HasIndex(e => e.DomainId, "dnd_domainvariant_dnd_domainvariant_a2431ea");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DeitiesText)
                .IsRequired()
                .HasColumnType("varchar(128)")
                .HasColumnName("deities_text");
            entity.Property(e => e.DomainId)
                .HasColumnType("int(11)")
                .HasColumnName("domain_id");
            entity.Property(e => e.GrantedPower)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("granted_power");
            entity.Property(e => e.GrantedPowerHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("granted_power_html");
            entity.Property(e => e.GrantedPowerType)
                .IsRequired()
                .HasColumnType("varchar(8)")
                .HasColumnName("granted_power_type");
            entity.Property(e => e.Page)
                .HasDefaultValueSql("NULL")
                .HasColumnType("smallint(5)")
                .HasColumnName("page");
            entity.Property(e => e.Requirement)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("requirement");
            entity.Property(e => e.RulebookId)
                .HasColumnType("int(11)")
                .HasColumnName("rulebook_id");

            entity.HasOne(d => d.Domain).WithMany(p => p.DndDomainvariants)
                .HasForeignKey(d => d.DomainId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Rulebook).WithMany(p => p.DndDomainvariants)
                .HasForeignKey(d => d.RulebookId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndDomainvariantDeity>(entity =>
        {
            entity.ToTable("dnd_domainvariant_deities");

            entity.HasIndex(e => e.DomainvariantId, "dnd_domainvariant_deities_dnd_domainvariant_deities_226d9ee2");

            entity.HasIndex(e => e.DeityId, "dnd_domainvariant_deities_dnd_domainvariant_deities_27307746");

            entity.HasIndex(e => new { e.DomainvariantId, e.DeityId }, "dnd_domainvariant_deities_dnd_domainvariant_deities_domainvariant_id_e102dfb14ee5c6d_uniq");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DeityId)
                .HasColumnType("int(11)")
                .HasColumnName("deity_id");
            entity.Property(e => e.DomainvariantId)
                .HasColumnType("int(11)")
                .HasColumnName("domainvariant_id");

            entity.HasOne(d => d.Deity).WithMany(p => p.DndDomainvariantDeities)
                .HasForeignKey(d => d.DeityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Domainvariant).WithMany(p => p.DndDomainvariantDeities)
                .HasForeignKey(d => d.DomainvariantId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndDomainvariantOtherDeity>(entity =>
        {
            entity.ToTable("dnd_domainvariant_other_deities");

            entity.HasIndex(e => new { e.DomainvariantId, e.DeityId }, "dnd_domainvariant_other_deities_dnd_domainvariant_other_d_domainvariant_id_a674a18dfab6630_uniq");

            entity.HasIndex(e => e.DomainvariantId, "dnd_domainvariant_other_deities_dnd_domainvariant_other_deities_226d9ee2");

            entity.HasIndex(e => e.DeityId, "dnd_domainvariant_other_deities_dnd_domainvariant_other_deities_27307746");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DeityId)
                .HasColumnType("int(11)")
                .HasColumnName("deity_id");
            entity.Property(e => e.DomainvariantId)
                .HasColumnType("int(11)")
                .HasColumnName("domainvariant_id");

            entity.HasOne(d => d.Deity).WithMany(p => p.DndDomainvariantOtherDeities)
                .HasForeignKey(d => d.DeityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Domainvariant).WithMany(p => p.DndDomainvariantOtherDeities)
                .HasForeignKey(d => d.DomainvariantId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndFeat>(entity =>
        {
            entity.ToTable("dnd_feat");

            entity.HasIndex(e => e.RulebookId, "dnd_feat_dnd_feat_51956a35");

            entity.HasIndex(e => e.Slug, "dnd_feat_dnd_feat_a951d5d6");

            entity.HasIndex(e => e.Name, "dnd_feat_dnd_feat_name");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Benefit)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("benefit");
            entity.Property(e => e.BenefitHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("benefit_html");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("description");
            entity.Property(e => e.DescriptionHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("description_html");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("name");
            entity.Property(e => e.Normal)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("normal");
            entity.Property(e => e.NormalHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("normal_html");
            entity.Property(e => e.Page)
                .HasDefaultValueSql("NULL")
                .HasColumnType("smallint(5)")
                .HasColumnName("page");
            entity.Property(e => e.RulebookId)
                .HasColumnType("int(11)")
                .HasColumnName("rulebook_id");
            entity.Property(e => e.Slug)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("slug");
            entity.Property(e => e.Special)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("special");
            entity.Property(e => e.SpecialHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("special_html");

            entity.HasOne(d => d.Rulebook).WithMany(p => p.DndFeats)
                .HasForeignKey(d => d.RulebookId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndFeatFeatCategory>(entity =>
        {
            entity.ToTable("dnd_feat_feat_categories");

            entity.HasIndex(e => e.FeatId, "dnd_feat_feat_categories_dnd_feat_feat_categories_2f59e7d8");

            entity.HasIndex(e => e.FeatcategoryId, "dnd_feat_feat_categories_dnd_feat_feat_categories_5509d08");

            entity.HasIndex(e => new { e.FeatId, e.FeatcategoryId }, "dnd_feat_feat_categories_dnd_feat_feat_categories_feat_id_3a0b9d0392305885_uniq");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.FeatId)
                .HasColumnType("int(11)")
                .HasColumnName("feat_id");
            entity.Property(e => e.FeatcategoryId)
                .HasColumnType("int(11)")
                .HasColumnName("featcategory_id");

            entity.HasOne(d => d.Feat).WithMany(p => p.DndFeatFeatCategories)
                .HasForeignKey(d => d.FeatId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Featcategory).WithMany(p => p.DndFeatFeatCategories)
                .HasForeignKey(d => d.FeatcategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndFeatcategory>(entity =>
        {
            entity.ToTable("dnd_featcategory");

            entity.HasIndex(e => e.Slug, "dnd_featcategory_dnd_featcategory_a951d5d6");

            entity.HasIndex(e => e.Name, "dnd_featcategory_dnd_featcategory_name_uniq");

            entity.HasIndex(e => e.Slug, "dnd_featcategory_dnd_featcategory_slug_uniq");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("name");
            entity.Property(e => e.Slug)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("slug");
        });

        modelBuilder.Entity<DndFeatrequiresfeat>(entity =>
        {
            entity.ToTable("dnd_featrequiresfeat");

            entity.HasIndex(e => e.RequiredFeatId, "dnd_featrequiresfeat_dnd_featrequiresfeat_8238d861");

            entity.HasIndex(e => e.SourceFeatId, "dnd_featrequiresfeat_dnd_featrequiresfeat_dc102e93");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AdditionalText)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("additional_text");
            entity.Property(e => e.RequiredFeatId)
                .HasColumnType("int(11)")
                .HasColumnName("required_feat_id");
            entity.Property(e => e.SourceFeatId)
                .HasColumnType("int(11)")
                .HasColumnName("source_feat_id");

            entity.HasOne(d => d.RequiredFeat).WithMany(p => p.DndFeatrequiresfeatRequiredFeats)
                .HasForeignKey(d => d.RequiredFeatId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.SourceFeat).WithMany(p => p.DndFeatrequiresfeatSourceFeats)
                .HasForeignKey(d => d.SourceFeatId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndFeatrequiresskill>(entity =>
        {
            entity.ToTable("dnd_featrequiresskill");

            entity.HasIndex(e => e.FeatId, "dnd_featrequiresskill_dnd_featrequiresskill_2f59e7d8");

            entity.HasIndex(e => e.SkillId, "dnd_featrequiresskill_dnd_featrequiresskill_30f70346");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Extra)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("extra");
            entity.Property(e => e.FeatId)
                .HasColumnType("int(11)")
                .HasColumnName("feat_id");
            entity.Property(e => e.MinRank)
                .HasColumnType("smallint(5)")
                .HasColumnName("min_rank");
            entity.Property(e => e.SkillId)
                .HasColumnType("int(11)")
                .HasColumnName("skill_id");

            entity.HasOne(d => d.Feat).WithMany(p => p.DndFeatrequiresskills)
                .HasForeignKey(d => d.FeatId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Skill).WithMany(p => p.DndFeatrequiresskills)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndFeatspecialfeatprerequisite>(entity =>
        {
            entity.ToTable("dnd_featspecialfeatprerequisite");

            entity.HasIndex(e => e.FeatId, "dnd_featspecialfeatprerequisite_dnd_featspecialfeatprerequisite_2f59e7d8");

            entity.HasIndex(e => e.SpecialFeatPrerequisiteId, "dnd_featspecialfeatprerequisite_dnd_featspecialfeatprerequisite_c2048d74");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.FeatId)
                .HasColumnType("int(11)")
                .HasColumnName("feat_id");
            entity.Property(e => e.SpecialFeatPrerequisiteId)
                .HasColumnType("int(11)")
                .HasColumnName("special_feat_prerequisite_id");
            entity.Property(e => e.Value1)
                .IsRequired()
                .HasColumnType("varchar(256)")
                .HasColumnName("value_1");
            entity.Property(e => e.Value2)
                .IsRequired()
                .HasColumnType("varchar(256)")
                .HasColumnName("value_2");

            entity.HasOne(d => d.Feat).WithMany(p => p.DndFeatspecialfeatprerequisites)
                .HasForeignKey(d => d.FeatId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.SpecialFeatPrerequisite).WithMany(p => p.DndFeatspecialfeatprerequisites)
                .HasForeignKey(d => d.SpecialFeatPrerequisiteId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndItem>(entity =>
        {
            entity.ToTable("dnd_item");

            entity.HasIndex(e => e.BodySlotId, "dnd_item_dnd_item_35a44c52");

            entity.HasIndex(e => e.RulebookId, "dnd_item_dnd_item_51956a35");

            entity.HasIndex(e => e.Name, "dnd_item_dnd_item_52094d6e");

            entity.HasIndex(e => e.PropertyId, "dnd_item_dnd_item_6a812853");

            entity.HasIndex(e => e.ActivationId, "dnd_item_dnd_item_a7ff055e");

            entity.HasIndex(e => e.AuraId, "dnd_item_dnd_item_c181fb11");

            entity.HasIndex(e => e.SynergyPrerequisiteId, "dnd_item_dnd_item_ed720ca8");

            entity.HasIndex(e => e.Slug, "dnd_item_slug");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ActivationId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("int(11)")
                .HasColumnName("activation_id");
            entity.Property(e => e.AuraDc)
                .IsRequired()
                .HasColumnType("varchar(16)")
                .HasColumnName("aura_dc");
            entity.Property(e => e.AuraId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("int(11)")
                .HasColumnName("aura_id");
            entity.Property(e => e.BodySlotId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("int(11)")
                .HasColumnName("body_slot_id");
            entity.Property(e => e.CasterLevel)
                .HasDefaultValueSql("NULL")
                .HasColumnType("smallint(5)")
                .HasColumnName("caster_level");
            entity.Property(e => e.CostToCreate)
                .IsRequired()
                .HasColumnType("varchar(128)")
                .HasColumnName("cost_to_create");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("description");
            entity.Property(e => e.DescriptionHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("description_html");
            entity.Property(e => e.ItemLevel)
                .HasDefaultValueSql("NULL")
                .HasColumnType("smallint(5)")
                .HasColumnName("item_level");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("name");
            entity.Property(e => e.Page)
                .HasDefaultValueSql("NULL")
                .HasColumnType("smallint(5)")
                .HasColumnName("page");
            entity.Property(e => e.PriceBonus)
                .HasDefaultValueSql("NULL")
                .HasColumnType("smallint(5)")
                .HasColumnName("price_bonus");
            entity.Property(e => e.PriceGp)
                .HasDefaultValueSql("NULL")
                .HasColumnType("int(10)")
                .HasColumnName("price_gp");
            entity.Property(e => e.PropertyId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("int(11)")
                .HasColumnName("property_id");
            entity.Property(e => e.RequiredExtra)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("required_extra");
            entity.Property(e => e.RulebookId)
                .HasColumnType("int(11)")
                .HasColumnName("rulebook_id");
            entity.Property(e => e.Slug)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("slug");
            entity.Property(e => e.SynergyPrerequisiteId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("int(11)")
                .HasColumnName("synergy_prerequisite_id");
            entity.Property(e => e.Type)
                .IsRequired()
                .HasColumnType("varchar(3)")
                .HasColumnName("type");
            entity.Property(e => e.VisualDescription)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("visual_description");
            entity.Property(e => e.Weight)
                .HasDefaultValueSql("NULL")
                .HasColumnType("double")
                .HasColumnName("weight");

            entity.HasOne(d => d.Activation).WithMany(p => p.DndItems).HasForeignKey(d => d.ActivationId);

            entity.HasOne(d => d.Aura).WithMany(p => p.DndItems).HasForeignKey(d => d.AuraId);

            entity.HasOne(d => d.BodySlot).WithMany(p => p.DndItems).HasForeignKey(d => d.BodySlotId);

            entity.HasOne(d => d.Property).WithMany(p => p.DndItems).HasForeignKey(d => d.PropertyId);

            entity.HasOne(d => d.Rulebook).WithMany(p => p.DndItems)
                .HasForeignKey(d => d.RulebookId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.SynergyPrerequisite).WithMany(p => p.InverseSynergyPrerequisite).HasForeignKey(d => d.SynergyPrerequisiteId);
        });

        modelBuilder.Entity<DndItemAuraSchool>(entity =>
        {
            entity.ToTable("dnd_item_aura_schools");

            entity.HasIndex(e => e.ItemId, "dnd_item_aura_schools_dnd_item_aura_schools_67b70d25");

            entity.HasIndex(e => e.SpellschoolId, "dnd_item_aura_schools_dnd_item_aura_schools_a7db21ef");

            entity.HasIndex(e => new { e.ItemId, e.SpellschoolId }, "dnd_item_aura_schools_dnd_item_aura_schools_item_id_345bdf3601d7f155_uniq");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ItemId)
                .HasColumnType("int(11)")
                .HasColumnName("item_id");
            entity.Property(e => e.SpellschoolId)
                .HasColumnType("int(11)")
                .HasColumnName("spellschool_id");

            entity.HasOne(d => d.Item).WithMany(p => p.DndItemAuraSchools)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Spellschool).WithMany(p => p.DndItemAuraSchools)
                .HasForeignKey(d => d.SpellschoolId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndItemRequiredFeat>(entity =>
        {
            entity.ToTable("dnd_item_required_feats");

            entity.HasIndex(e => e.FeatId, "dnd_item_required_feats_dnd_item_required_feats_2f59e7d8");

            entity.HasIndex(e => e.ItemId, "dnd_item_required_feats_dnd_item_required_feats_67b70d25");

            entity.HasIndex(e => new { e.ItemId, e.FeatId }, "dnd_item_required_feats_dnd_item_required_feats_item_id_86ffea90e89a0f2_uniq");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.FeatId)
                .HasColumnType("int(11)")
                .HasColumnName("feat_id");
            entity.Property(e => e.ItemId)
                .HasColumnType("int(11)")
                .HasColumnName("item_id");

            entity.HasOne(d => d.Feat).WithMany(p => p.DndItemRequiredFeats)
                .HasForeignKey(d => d.FeatId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Item).WithMany(p => p.DndItemRequiredFeats)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndItemRequiredSpell>(entity =>
        {
            entity.ToTable("dnd_item_required_spells");

            entity.HasIndex(e => e.ItemId, "dnd_item_required_spells_dnd_item_required_spells_67b70d25");

            entity.HasIndex(e => e.SpellId, "dnd_item_required_spells_dnd_item_required_spells_a091809d");

            entity.HasIndex(e => new { e.ItemId, e.SpellId }, "dnd_item_required_spells_dnd_item_required_spells_item_id_4420551901ef62b4_uniq");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ItemId)
                .HasColumnType("int(11)")
                .HasColumnName("item_id");
            entity.Property(e => e.SpellId)
                .HasColumnType("int(11)")
                .HasColumnName("spell_id");

            entity.HasOne(d => d.Item).WithMany(p => p.DndItemRequiredSpells)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Spell).WithMany(p => p.DndItemRequiredSpells)
                .HasForeignKey(d => d.SpellId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndItemactivationtype>(entity =>
        {
            entity.ToTable("dnd_itemactivationtype");

            entity.HasIndex(e => e.Name, "dnd_itemactivationtype_dnd_itemactivationtype_52094d6e");

            entity.HasIndex(e => e.Slug, "dnd_itemactivationtype_slug");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("name");
            entity.Property(e => e.Slug)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("slug");
        });

        modelBuilder.Entity<DndItemauratype>(entity =>
        {
            entity.ToTable("dnd_itemauratype");

            entity.HasIndex(e => e.Name, "dnd_itemauratype_dnd_itemauratype_52094d6e");

            entity.HasIndex(e => e.Slug, "dnd_itemauratype_slug");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("name");
            entity.Property(e => e.Slug)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("slug");
        });

        modelBuilder.Entity<DndItemproperty>(entity =>
        {
            entity.ToTable("dnd_itemproperty");

            entity.HasIndex(e => e.Name, "dnd_itemproperty_dnd_itemproperty_52094d6e");

            entity.HasIndex(e => e.Slug, "dnd_itemproperty_slug");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("name");
            entity.Property(e => e.Slug)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("slug");
        });

        modelBuilder.Entity<DndItemslot>(entity =>
        {
            entity.ToTable("dnd_itemslot");

            entity.HasIndex(e => e.Name, "dnd_itemslot_dnd_itemslot_52094d6e");

            entity.HasIndex(e => e.Slug, "dnd_itemslot_slug");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("name");
            entity.Property(e => e.Slug)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("slug");
        });

        modelBuilder.Entity<DndLanguage>(entity =>
        {
            entity.ToTable("dnd_language");

            entity.HasIndex(e => e.Slug, "dnd_language_slug");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("description");
            entity.Property(e => e.DescriptionHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("description_html");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("name");
            entity.Property(e => e.Slug)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("slug");
        });

        modelBuilder.Entity<DndMonster>(entity =>
        {
            entity.ToTable("dnd_monster");

            entity.HasIndex(e => e.RulebookId, "dnd_monster_dnd_monster_51956a35");

            entity.HasIndex(e => e.Name, "dnd_monster_dnd_monster_52094d6e");

            entity.HasIndex(e => e.SizeId, "dnd_monster_dnd_monster_6154b20f");

            entity.HasIndex(e => e.TypeId, "dnd_monster_dnd_monster_777d41c8");

            entity.HasIndex(e => e.Slug, "dnd_monster_dnd_monster_a951d5d6");

            entity.HasIndex(e => new { e.Name, e.RulebookId }, "dnd_monster_dnd_monster_name_5810a781de09be1f_uniq");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Advancement)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("advancement");
            entity.Property(e => e.Alignment)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("alignment");
            entity.Property(e => e.ArmorClass)
                .IsRequired()
                .HasDefaultValue("32 (–1 size, +4 Dex, +19 natural)")
                .HasColumnType("varchar(128)")
                .HasColumnName("armor_class");
            entity.Property(e => e.Attack)
                .IsRequired()
                .HasDefaultValue("+3 greatsword +23 melee (3d6+13/19–20) or slam +20 melee (2d8+10)")
                .HasColumnType("varchar(128)")
                .HasColumnName("attack");
            entity.Property(e => e.BaseAttack)
                .HasColumnType("smallint(6)")
                .HasColumnName("base_attack");
            entity.Property(e => e.Cha)
                .HasColumnType("smallint(6)")
                .HasColumnName("cha");
            entity.Property(e => e.ChallengeRating)
                .HasColumnType("smallint(5)")
                .HasColumnName("challenge_rating");
            entity.Property(e => e.Combat)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("combat");
            entity.Property(e => e.CombatHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("combat_html");
            entity.Property(e => e.Con)
                .HasDefaultValueSql("NULL")
                .HasColumnType("smallint(6)")
                .HasColumnName("con");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("description");
            entity.Property(e => e.DescriptionHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("description_html");
            entity.Property(e => e.Dex)
                .HasColumnType("smallint(6)")
                .HasColumnName("dex");
            entity.Property(e => e.Environment)
                .IsRequired()
                .HasColumnType("varchar(128)")
                .HasColumnName("environment");
            entity.Property(e => e.FlatFootedArmorClass)
                .HasDefaultValueSql("NULL")
                .HasColumnType("smallint(6)")
                .HasColumnName("flat_footed_armor_class");
            entity.Property(e => e.FortSave)
                .HasColumnType("smallint(6)")
                .HasColumnName("fort_save");
            entity.Property(e => e.FortSaveExtra)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("fort_save_extra");
            entity.Property(e => e.FullAttack)
                .IsRequired()
                .HasDefaultValue("+3 greatsword +23/+18/+13 melee (3d6+13/19–20) or slam +20 melee (2d8+10)")
                .HasColumnType("varchar(128)")
                .HasColumnName("full_attack");
            entity.Property(e => e.Grapple)
                .HasColumnType("smallint(6)")
                .HasColumnName("grapple");
            entity.Property(e => e.HitDice)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("hit_dice");
            entity.Property(e => e.Initiative)
                .HasColumnType("smallint(6)")
                .HasColumnName("initiative");
            entity.Property(e => e.Int)
                .HasColumnType("smallint(6)")
                .HasColumnName("int");
            entity.Property(e => e.LevelAdjustment)
                .HasDefaultValueSql("NULL")
                .HasColumnType("smallint(6)")
                .HasColumnName("level_adjustment");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("name");
            entity.Property(e => e.Organization)
                .IsRequired()
                .HasColumnType("varchar(128)")
                .HasColumnName("organization");
            entity.Property(e => e.Page)
                .HasDefaultValueSql("NULL")
                .HasColumnType("smallint(5)")
                .HasColumnName("page");
            entity.Property(e => e.Reach)
                .HasColumnType("smallint(5)")
                .HasColumnName("reach");
            entity.Property(e => e.ReflexSave)
                .HasColumnType("smallint(6)")
                .HasColumnName("reflex_save");
            entity.Property(e => e.ReflexSaveExtra)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("reflex_save_extra");
            entity.Property(e => e.RulebookId)
                .HasColumnType("int(11)")
                .HasColumnName("rulebook_id");
            entity.Property(e => e.SizeId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("int(11)")
                .HasColumnName("size_id");
            entity.Property(e => e.Slug)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("slug");
            entity.Property(e => e.Space)
                .HasColumnType("smallint(5)")
                .HasColumnName("space");
            entity.Property(e => e.SpecialAttacks)
                .IsRequired()
                .HasColumnType("varchar(256)")
                .HasColumnName("special_attacks");
            entity.Property(e => e.SpecialQualities)
                .IsRequired()
                .HasColumnType("varchar(512)")
                .HasColumnName("special_qualities");
            entity.Property(e => e.Str)
                .HasColumnType("smallint(6)")
                .HasColumnName("str");
            entity.Property(e => e.TouchArmorClass)
                .HasDefaultValueSql("NULL")
                .HasColumnType("smallint(6)")
                .HasColumnName("touch_armor_class");
            entity.Property(e => e.Treasure)
                .IsRequired()
                .HasColumnType("varchar(128)")
                .HasColumnName("treasure");
            entity.Property(e => e.TypeId)
                .HasColumnType("int(11)")
                .HasColumnName("type_id");
            entity.Property(e => e.WillSave)
                .HasColumnType("smallint(6)")
                .HasColumnName("will_save");
            entity.Property(e => e.WillSaveExtra)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("will_save_extra");
            entity.Property(e => e.Wis)
                .HasColumnType("smallint(6)")
                .HasColumnName("wis");

            entity.HasOne(d => d.Rulebook).WithMany(p => p.DndMonsters)
                .HasForeignKey(d => d.RulebookId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Size).WithMany(p => p.DndMonsters).HasForeignKey(d => d.SizeId);

            entity.HasOne(d => d.Type).WithMany(p => p.DndMonsters)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndMonsterSubtype>(entity =>
        {
            entity.ToTable("dnd_monster_subtypes");

            entity.HasIndex(e => e.MonstersubtypeId, "dnd_monster_subtypes_dnd_monster_subtypes_3c3013de");

            entity.HasIndex(e => e.MonsterId, "dnd_monster_subtypes_dnd_monster_subtypes_6608660b");

            entity.HasIndex(e => new { e.MonsterId, e.MonstersubtypeId }, "dnd_monster_subtypes_dnd_monster_subtypes_monster_id_7716d36de2720dc0_uniq");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.MonsterId)
                .HasColumnType("int(11)")
                .HasColumnName("monster_id");
            entity.Property(e => e.MonstersubtypeId)
                .HasColumnType("int(11)")
                .HasColumnName("monstersubtype_id");

            entity.HasOne(d => d.Monster).WithMany(p => p.DndMonsterSubtypes)
                .HasForeignKey(d => d.MonsterId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Monstersubtype).WithMany(p => p.DndMonsterSubtypes)
                .HasForeignKey(d => d.MonstersubtypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndMonsterhasfeat>(entity =>
        {
            entity.ToTable("dnd_monsterhasfeat");

            entity.HasIndex(e => e.FeatId, "dnd_monsterhasfeat_dnd_monsterhasfeat_2f59e7d8");

            entity.HasIndex(e => e.MonsterId, "dnd_monsterhasfeat_dnd_monsterhasfeat_6608660b");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Extra)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("extra");
            entity.Property(e => e.FeatId)
                .HasColumnType("int(11)")
                .HasColumnName("feat_id");
            entity.Property(e => e.MonsterId)
                .HasColumnType("int(11)")
                .HasColumnName("monster_id");

            entity.HasOne(d => d.Feat).WithMany(p => p.DndMonsterhasfeats)
                .HasForeignKey(d => d.FeatId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Monster).WithMany(p => p.DndMonsterhasfeats)
                .HasForeignKey(d => d.MonsterId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndMonsterhasskill>(entity =>
        {
            entity.ToTable("dnd_monsterhasskill");

            entity.HasIndex(e => e.SkillId, "dnd_monsterhasskill_dnd_monsterhasskill_30f70346");

            entity.HasIndex(e => e.MonsterId, "dnd_monsterhasskill_dnd_monsterhasskill_6608660b");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Extra)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("extra");
            entity.Property(e => e.MonsterId)
                .HasColumnType("int(11)")
                .HasColumnName("monster_id");
            entity.Property(e => e.Ranks)
                .HasColumnType("smallint(5)")
                .HasColumnName("ranks");
            entity.Property(e => e.SkillId)
                .HasColumnType("int(11)")
                .HasColumnName("skill_id");

            entity.HasOne(d => d.Monster).WithMany(p => p.DndMonsterhasskills)
                .HasForeignKey(d => d.MonsterId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Skill).WithMany(p => p.DndMonsterhasskills)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndMonsterspeed>(entity =>
        {
            entity.ToTable("dnd_monsterspeed");

            entity.HasIndex(e => e.RaceId, "dnd_monsterspeed_dnd_monsterspeed_3548c065");

            entity.HasIndex(e => e.TypeId, "dnd_monsterspeed_dnd_monsterspeed_777d41c8");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.RaceId)
                .HasColumnType("int(11)")
                .HasColumnName("race_id");
            entity.Property(e => e.Speed)
                .HasColumnType("smallint(5)")
                .HasColumnName("speed");
            entity.Property(e => e.TypeId)
                .HasColumnType("int(11)")
                .HasColumnName("type_id");

            entity.HasOne(d => d.Race).WithMany(p => p.DndMonsterspeeds)
                .HasForeignKey(d => d.RaceId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Type).WithMany(p => p.DndMonsterspeeds)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndMonstersubtype1>(entity =>
        {
            entity.ToTable("dnd_monstersubtype");

            entity.HasIndex(e => e.Name, "dnd_monstersubtype_dnd_monstersubtype_52094d6e");

            entity.HasIndex(e => e.Slug, "dnd_monstersubtype_dnd_monstersubtype_a951d5d6");

            entity.HasIndex(e => e.Slug, "dnd_monstersubtype_dnd_monstersubtype_slug_uniq");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("name");
            entity.Property(e => e.Slug)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("slug");
        });

        modelBuilder.Entity<DndMonstertype>(entity =>
        {
            entity.ToTable("dnd_monstertype");

            entity.HasIndex(e => e.Name, "dnd_monstertype_dnd_monstertype_52094d6e");

            entity.HasIndex(e => e.Slug, "dnd_monstertype_dnd_monstertype_a951d5d6");

            entity.HasIndex(e => e.Slug, "dnd_monstertype_dnd_monstertype_slug_uniq");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("name");
            entity.Property(e => e.Slug)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("slug");
        });

        modelBuilder.Entity<DndNewsentry>(entity =>
        {
            entity.ToTable("dnd_newsentry");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Body)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("body");
            entity.Property(e => e.BodyHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("body_html");
            entity.Property(e => e.Enabled)
                .HasColumnType("tinyint(1)")
                .HasColumnName("enabled");
            entity.Property(e => e.Published)
                .HasColumnType("date")
                .HasColumnName("published");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("title");
        });

        modelBuilder.Entity<DndRace>(entity =>
        {
            entity.ToTable("dnd_race");

            entity.HasIndex(e => e.RaceTypeId, "dnd_race_dnd_race_34628d95");

            entity.HasIndex(e => e.RulebookId, "dnd_race_dnd_race_51956a35");

            entity.HasIndex(e => e.Name, "dnd_race_dnd_race_52094d6e");

            entity.HasIndex(e => e.SizeId, "dnd_race_dnd_race_6154b20f");

            entity.HasIndex(e => e.Slug, "dnd_race_dnd_race_a951d5d6");

            entity.HasIndex(e => new { e.Name, e.RulebookId }, "dnd_race_dnd_race_name_64b932b074325211_uniq");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Cha)
                .HasColumnType("smallint(6)")
                .HasColumnName("cha");
            entity.Property(e => e.Combat)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("combat");
            entity.Property(e => e.CombatHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("combat_html");
            entity.Property(e => e.Con)
                .HasDefaultValueSql("NULL")
                .HasColumnType("smallint(6)")
                .HasColumnName("con");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("description");
            entity.Property(e => e.DescriptionHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("description_html");
            entity.Property(e => e.Dex)
                .HasColumnType("smallint(6)")
                .HasColumnName("dex");
            entity.Property(e => e.Image)
                .HasDefaultValueSql("NULL")
                .HasColumnType("varchar(100)")
                .HasColumnName("image");
            entity.Property(e => e.Int)
                .HasColumnType("smallint(6)")
                .HasColumnName("int");
            entity.Property(e => e.LevelAdjustment)
                .HasDefaultValueSql("'0'")
                .HasColumnType("smallint(6)")
                .HasColumnName("level_adjustment");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("name");
            entity.Property(e => e.NaturalArmor)
                .HasDefaultValueSql("NULL")
                .HasColumnType("smallint(6)")
                .HasColumnName("natural_armor");
            entity.Property(e => e.Page)
                .HasDefaultValueSql("NULL")
                .HasColumnType("smallint(5)")
                .HasColumnName("page");
            entity.Property(e => e.RaceTypeId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("int(11)")
                .HasColumnName("race_type_id");
            entity.Property(e => e.RacialHitDiceCount)
                .HasDefaultValueSql("NULL")
                .HasColumnType("smallint(5)")
                .HasColumnName("racial_hit_dice_count");
            entity.Property(e => e.RacialTraits)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("racial_traits");
            entity.Property(e => e.RacialTraitsHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("racial_traits_html");
            entity.Property(e => e.Reach)
                .HasDefaultValueSql("'5'")
                .HasColumnType("smallint(5)")
                .HasColumnName("reach");
            entity.Property(e => e.RulebookId)
                .HasColumnType("int(11)")
                .HasColumnName("rulebook_id");
            entity.Property(e => e.SizeId)
                .HasDefaultValueSql("'5'")
                .HasColumnType("int(11)")
                .HasColumnName("size_id");
            entity.Property(e => e.Slug)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("slug");
            entity.Property(e => e.Space)
                .HasDefaultValueSql("'5'")
                .HasColumnType("smallint(5)")
                .HasColumnName("space");
            entity.Property(e => e.Str)
                .HasColumnType("smallint(6)")
                .HasColumnName("str");
            entity.Property(e => e.Wis)
                .HasColumnType("smallint(6)")
                .HasColumnName("wis");

            entity.HasOne(d => d.RaceType).WithMany(p => p.DndRaces).HasForeignKey(d => d.RaceTypeId);

            entity.HasOne(d => d.Rulebook).WithMany(p => p.DndRaces)
                .HasForeignKey(d => d.RulebookId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Size).WithMany(p => p.DndRaces)
                .HasForeignKey(d => d.SizeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndRaceAutomaticLanguage>(entity =>
        {
            entity.ToTable("dnd_race_automatic_languages");

            entity.HasIndex(e => e.RaceId, "dnd_race_automatic_languages_dnd_race_automatic_languages_3548c065");

            entity.HasIndex(e => e.LanguageId, "dnd_race_automatic_languages_dnd_race_automatic_languages_7ab48146");

            entity.HasIndex(e => new { e.RaceId, e.LanguageId }, "dnd_race_automatic_languages_dnd_race_automatic_languages_race_id_4ef05d055298a9df_uniq");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.LanguageId)
                .HasColumnType("int(11)")
                .HasColumnName("language_id");
            entity.Property(e => e.RaceId)
                .HasColumnType("int(11)")
                .HasColumnName("race_id");

            entity.HasOne(d => d.Language).WithMany(p => p.DndRaceAutomaticLanguages)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Race).WithMany(p => p.DndRaceAutomaticLanguages)
                .HasForeignKey(d => d.RaceId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndRaceBonusLanguage>(entity =>
        {
            entity.ToTable("dnd_race_bonus_languages");

            entity.HasIndex(e => e.RaceId, "dnd_race_bonus_languages_dnd_race_bonus_languages_3548c065");

            entity.HasIndex(e => e.LanguageId, "dnd_race_bonus_languages_dnd_race_bonus_languages_7ab48146");

            entity.HasIndex(e => new { e.RaceId, e.LanguageId }, "dnd_race_bonus_languages_dnd_race_bonus_languages_race_id_1922bed42ad1b62b_uniq");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.LanguageId)
                .HasColumnType("int(11)")
                .HasColumnName("language_id");
            entity.Property(e => e.RaceId)
                .HasColumnType("int(11)")
                .HasColumnName("race_id");

            entity.HasOne(d => d.Language).WithMany(p => p.DndRaceBonusLanguages)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Race).WithMany(p => p.DndRaceBonusLanguages)
                .HasForeignKey(d => d.RaceId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndRacefavoredcharacterclass>(entity =>
        {
            entity.ToTable("dnd_racefavoredcharacterclass");

            entity.HasIndex(e => e.RaceId, "dnd_racefavoredcharacterclass_dnd_racefavoredcharacterclass_3548c065");

            entity.HasIndex(e => e.CharacterClassId, "dnd_racefavoredcharacterclass_dnd_racefavoredcharacterclass_4d1287f7");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CharacterClassId)
                .HasColumnType("int(11)")
                .HasColumnName("character_class_id");
            entity.Property(e => e.Extra)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("extra");
            entity.Property(e => e.RaceId)
                .HasColumnType("int(11)")
                .HasColumnName("race_id");

            entity.HasOne(d => d.CharacterClass).WithMany(p => p.DndRacefavoredcharacterclasses)
                .HasForeignKey(d => d.CharacterClassId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Race).WithMany(p => p.DndRacefavoredcharacterclasses)
                .HasForeignKey(d => d.RaceId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndRacesize>(entity =>
        {
            entity.ToTable("dnd_racesize");

            entity.HasIndex(e => e.Name, "dnd_racesize_dnd_racesize_52094d6e");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("name");
            entity.Property(e => e.Order)
                .HasColumnType("smallint(5)")
                .HasColumnName("order");
        });

        modelBuilder.Entity<DndRacespeed>(entity =>
        {
            entity.ToTable("dnd_racespeed");

            entity.HasIndex(e => e.RaceId, "dnd_racespeed_dnd_racespeed_3548c065");

            entity.HasIndex(e => e.TypeId, "dnd_racespeed_dnd_racespeed_777d41c8");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.RaceId)
                .HasColumnType("int(11)")
                .HasColumnName("race_id");
            entity.Property(e => e.Speed)
                .HasColumnType("smallint(5)")
                .HasColumnName("speed");
            entity.Property(e => e.TypeId)
                .HasColumnType("int(11)")
                .HasColumnName("type_id");

            entity.HasOne(d => d.Race).WithMany(p => p.DndRacespeeds)
                .HasForeignKey(d => d.RaceId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Type).WithMany(p => p.DndRacespeeds)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndRacespeedtype>(entity =>
        {
            entity.ToTable("dnd_racespeedtype");

            entity.HasIndex(e => e.Name, "dnd_racespeedtype_dnd_racespeedtype_52094d6e");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Extra)
                .HasDefaultValueSql("NULL")
                .HasColumnType("varchar(32)")
                .HasColumnName("extra");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("name");
        });

        modelBuilder.Entity<DndRacetype>(entity =>
        {
            entity.ToTable("dnd_racetype");

            entity.HasIndex(e => e.Name, "dnd_racetype_dnd_racetype_52094d6e");

            entity.HasIndex(e => e.Slug, "dnd_racetype_slug");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.BaseAttackType)
                .IsRequired()
                .HasColumnType("varchar(3)")
                .HasColumnName("base_attack_type");
            entity.Property(e => e.BaseFortSaveType)
                .IsRequired()
                .HasColumnType("varchar(4)")
                .HasColumnName("base_fort_save_type");
            entity.Property(e => e.BaseReflexSaveType)
                .IsRequired()
                .HasColumnType("varchar(4)")
                .HasColumnName("base_reflex_save_type");
            entity.Property(e => e.BaseWillSaveType)
                .IsRequired()
                .HasColumnType("varchar(4)")
                .HasColumnName("base_will_save_type");
            entity.Property(e => e.HitDieSize)
                .HasColumnType("smallint(5)")
                .HasColumnName("hit_die_size");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("name");
            entity.Property(e => e.Slug)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("slug");
        });

        modelBuilder.Entity<DndRule>(entity =>
        {
            entity.ToTable("dnd_rule");

            entity.HasIndex(e => e.RulebookId, "dnd_rule_dnd_rule_51956a35");

            entity.HasIndex(e => e.Name, "dnd_rule_dnd_rule_52094d6e");

            entity.HasIndex(e => e.Slug, "dnd_rule_slug");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Body)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("body");
            entity.Property(e => e.BodyHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("body_html");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("name");
            entity.Property(e => e.PageFrom)
                .HasDefaultValueSql("NULL")
                .HasColumnType("smallint(5)")
                .HasColumnName("page_from");
            entity.Property(e => e.PageTo)
                .HasDefaultValueSql("NULL")
                .HasColumnType("smallint(5)")
                .HasColumnName("page_to");
            entity.Property(e => e.RulebookId)
                .HasColumnType("int(11)")
                .HasColumnName("rulebook_id");
            entity.Property(e => e.Slug)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("slug");

            entity.HasOne(d => d.Rulebook).WithMany(p => p.DndRules)
                .HasForeignKey(d => d.RulebookId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndRulebook>(entity =>
        {
            entity.ToTable("dnd_rulebook");

            entity.HasIndex(e => e.DndEditionId, "dnd_rulebook_dnd_rulebook_66a88bda");

            entity.HasIndex(e => e.Slug, "dnd_rulebook_dnd_rulebook_a951d5d6");

            entity.HasIndex(e => e.Name, "dnd_rulebook_dnd_rulebook_name");

            entity.HasIndex(e => e.Slug, "dnd_rulebook_dnd_rulebook_slug_uniq");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Abbr)
                .IsRequired()
                .HasColumnType("varchar(7)")
                .HasColumnName("abbr");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("description");
            entity.Property(e => e.DndEditionId)
                .HasColumnType("int(11)")
                .HasColumnName("dnd_edition_id");
            entity.Property(e => e.Image)
                .HasDefaultValueSql("NULL")
                .HasColumnType("varchar(100)")
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(128)")
                .HasColumnName("name");
            entity.Property(e => e.OfficialUrl)
                .IsRequired()
                .HasColumnType("varchar(255)")
                .HasColumnName("official_url");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("NULL")
                .HasColumnType("date")
                .HasColumnName("published");
            entity.Property(e => e.Slug)
                .IsRequired()
                .HasColumnType("varchar(128)")
                .HasColumnName("slug");
            entity.Property(e => e.Year)
                .HasDefaultValueSql("NULL")
                .HasColumnType("varchar(4)")
                .HasColumnName("year");

            entity.HasOne(d => d.DndEdition).WithMany(p => p.DndRulebooks)
                .HasForeignKey(d => d.DndEditionId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndRulesCondition>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("dnd_rules_conditions");

            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<DndSkill>(entity =>
        {
            entity.ToTable("dnd_skill");

            entity.HasIndex(e => e.Slug, "dnd_skill_dnd_skill_a951d5d6");

            entity.HasIndex(e => e.Name, "dnd_skill_dnd_skill_name_uniq");

            entity.HasIndex(e => e.Slug, "dnd_skill_dnd_skill_slug_uniq");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ArmorCheckPenalty)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(1)")
                .HasColumnName("armor_check_penalty");
            entity.Property(e => e.BaseSkill)
                .IsRequired()
                .HasColumnType("varchar(4)")
                .HasColumnName("base_skill");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("name");
            entity.Property(e => e.Slug)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("slug");
            entity.Property(e => e.TrainedOnly)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(1)")
                .HasColumnName("trained_only");
        });

        modelBuilder.Entity<DndSkillvariant>(entity =>
        {
            entity.ToTable("dnd_skillvariant");

            entity.HasIndex(e => e.SkillId, "dnd_skillvariant_dnd_skillvariant_30f70346");

            entity.HasIndex(e => e.RulebookId, "dnd_skillvariant_dnd_skillvariant_51956a35");

            entity.HasIndex(e => new { e.SkillId, e.RulebookId }, "dnd_skillvariant_dnd_skillvariant_skill_id_65a2ff28b87f4e1e_uniq");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Action)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("action");
            entity.Property(e => e.ActionHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("action_html");
            entity.Property(e => e.Check)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("check");
            entity.Property(e => e.CheckHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("check_html");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("description");
            entity.Property(e => e.DescriptionHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("description_html");
            entity.Property(e => e.Page)
                .HasDefaultValueSql("NULL")
                .HasColumnType("smallint(5)")
                .HasColumnName("page");
            entity.Property(e => e.Restriction)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("restriction");
            entity.Property(e => e.RestrictionHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("restriction_html");
            entity.Property(e => e.RulebookId)
                .HasColumnType("int(11)")
                .HasColumnName("rulebook_id");
            entity.Property(e => e.SkillId)
                .HasColumnType("int(11)")
                .HasColumnName("skill_id");
            entity.Property(e => e.Special)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("special");
            entity.Property(e => e.SpecialHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("special_html");
            entity.Property(e => e.Synergy)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("synergy");
            entity.Property(e => e.SynergyHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("synergy_html");
            entity.Property(e => e.TryAgain)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("try_again");
            entity.Property(e => e.TryAgainHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("try_again_html");
            entity.Property(e => e.Untrained)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("untrained");
            entity.Property(e => e.UntrainedHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("untrained_html");

            entity.HasOne(d => d.Rulebook).WithMany(p => p.DndSkillvariants)
                .HasForeignKey(d => d.RulebookId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Skill).WithMany(p => p.DndSkillvariants)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndSpecialfeatprerequisite>(entity =>
        {
            entity.ToTable("dnd_specialfeatprerequisite");

            entity.HasIndex(e => e.Name, "dnd_specialfeatprerequisite_name");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("name");
            entity.Property(e => e.PrintFormat)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("print_format");
        });

        modelBuilder.Entity<DndSpell>(entity =>
        {
            entity.ToTable("dnd_spell");

            entity.HasIndex(e => e.SchoolId, "dnd_spell_dnd_spell_1ebdc00a");

            entity.HasIndex(e => e.SubSchoolId, "dnd_spell_dnd_spell_20f50c5d");

            entity.HasIndex(e => e.RulebookId, "dnd_spell_dnd_spell_51956a35");

            entity.HasIndex(e => e.VerifiedAuthorId, "dnd_spell_dnd_spell_63f7f931");

            entity.HasIndex(e => e.Slug, "dnd_spell_dnd_spell_a951d5d6");

            entity.HasIndex(e => e.Name, "dnd_spell_dnd_spell_name");

            entity.HasIndex(e => new { e.Name, e.RulebookId }, "dnd_spell_dnd_spell_name_496ee28f7dbb33a7_uniq");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Added)
                .HasColumnType("datetime")
                .HasColumnName("added");
            entity.Property(e => e.ArcaneFocusComponent)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(1)")
                .HasColumnName("arcane_focus_component");
            entity.Property(e => e.Area)
                .HasDefaultValueSql("NULL")
                .HasColumnType("varchar(256)")
                .HasColumnName("area");
            entity.Property(e => e.CastingTime)
                .HasDefaultValueSql("NULL")
                .HasColumnType("varchar(256)")
                .HasColumnName("casting_time");
            entity.Property(e => e.CorruptComponent)
                .HasColumnType("tinyint(1)")
                .HasColumnName("corrupt_component");
            entity.Property(e => e.CorruptLevel)
                .HasDefaultValueSql("NULL")
                .HasColumnType("smallint(5)")
                .HasColumnName("corrupt_level");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("description");
            entity.Property(e => e.DescriptionHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("description_html");
            entity.Property(e => e.DivineFocusComponent)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(1)")
                .HasColumnName("divine_focus_component");
            entity.Property(e => e.Duration)
                .HasDefaultValueSql("NULL")
                .HasColumnType("varchar(256)")
                .HasColumnName("duration");
            entity.Property(e => e.Effect)
                .HasDefaultValueSql("NULL")
                .HasColumnType("varchar(256)")
                .HasColumnName("effect");
            entity.Property(e => e.ExtraComponents)
                .HasDefaultValueSql("NULL")
                .HasColumnType("varchar(256)")
                .HasColumnName("extra_components");
            entity.Property(e => e.MaterialComponent)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(1)")
                .HasColumnName("material_component");
            entity.Property(e => e.MetaBreathComponent)
                .HasColumnType("tinyint(1)")
                .HasColumnName("meta_breath_component");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("name");
            entity.Property(e => e.Page)
                .HasDefaultValueSql("NULL")
                .HasColumnType("smallint(5)")
                .HasColumnName("page");
            entity.Property(e => e.Range)
                .HasDefaultValueSql("NULL")
                .HasColumnType("varchar(256)")
                .HasColumnName("range");
            entity.Property(e => e.RulebookId)
                .HasColumnType("int(11)")
                .HasColumnName("rulebook_id");
            entity.Property(e => e.SavingThrow)
                .HasDefaultValueSql("NULL")
                .HasColumnType("varchar(128)")
                .HasColumnName("saving_throw");
            entity.Property(e => e.SchoolId)
                .HasColumnType("int(11)")
                .HasColumnName("school_id");
            entity.Property(e => e.Slug)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("slug");
            entity.Property(e => e.SomaticComponent)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(1)")
                .HasColumnName("somatic_component");
            entity.Property(e => e.SpellResistance)
                .HasDefaultValueSql("NULL")
                .HasColumnType("varchar(64)")
                .HasColumnName("spell_resistance");
            entity.Property(e => e.SubSchoolId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("int(11)")
                .HasColumnName("sub_school_id");
            entity.Property(e => e.Target)
                .HasDefaultValueSql("NULL")
                .HasColumnType("varchar(256)")
                .HasColumnName("target");
            entity.Property(e => e.TrueNameComponent)
                .HasColumnType("tinyint(1)")
                .HasColumnName("true_name_component");
            entity.Property(e => e.VerbalComponent)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(1)")
                .HasColumnName("verbal_component");
            entity.Property(e => e.Verified)
                .HasColumnType("tinyint(1)")
                .HasColumnName("verified");
            entity.Property(e => e.VerifiedAuthorId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("int(11)")
                .HasColumnName("verified_author_id");
            entity.Property(e => e.VerifiedTime)
                .HasDefaultValueSql("NULL")
                .HasColumnType("datetime")
                .HasColumnName("verified_time");
            entity.Property(e => e.XpComponent)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(1)")
                .HasColumnName("xp_component");

            entity.HasOne(d => d.Rulebook).WithMany(p => p.DndSpells)
                .HasForeignKey(d => d.RulebookId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.School).WithMany(p => p.DndSpells)
                .HasForeignKey(d => d.SchoolId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.SubSchool).WithMany(p => p.DndSpells).HasForeignKey(d => d.SubSchoolId);
        });

        modelBuilder.Entity<DndSpellDescriptor>(entity =>
        {
            entity.ToTable("dnd_spell_descriptors");

            entity.HasIndex(e => e.SpelldescriptorId, "dnd_spell_descriptors_dnd_spell_descriptors_30529786");

            entity.HasIndex(e => e.SpellId, "dnd_spell_descriptors_dnd_spell_descriptors_a091809d");

            entity.HasIndex(e => new { e.SpellId, e.SpelldescriptorId }, "dnd_spell_descriptors_dnd_spell_descriptors_spell_id_dbd1aa136fb353e_uniq");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.SpellId)
                .HasColumnType("int(11)")
                .HasColumnName("spell_id");
            entity.Property(e => e.SpelldescriptorId)
                .HasColumnType("int(11)")
                .HasColumnName("spelldescriptor_id");

            entity.HasOne(d => d.Spell).WithMany(p => p.DndSpellDescriptors)
                .HasForeignKey(d => d.SpellId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Spelldescriptor).WithMany(p => p.DndSpellDescriptors)
                .HasForeignKey(d => d.SpelldescriptorId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndSpellclasslevel>(entity =>
        {
            entity.ToTable("dnd_spellclasslevel");

            entity.HasIndex(e => e.CharacterClassId, "dnd_spellclasslevel_dnd_spellclasslevel_4d1287f7");

            entity.HasIndex(e => e.SpellId, "dnd_spellclasslevel_dnd_spellclasslevel_a091809d");

            entity.HasIndex(e => new { e.CharacterClassId, e.SpellId }, "dnd_spellclasslevel_dnd_spellclasslevel_character_class_id_3ae23c8563a83798_uniq");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CharacterClassId)
                .HasColumnType("int(11)")
                .HasColumnName("character_class_id");
            entity.Property(e => e.Extra)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("extra");
            entity.Property(e => e.Level)
                .HasColumnType("smallint(5)")
                .HasColumnName("level");
            entity.Property(e => e.SpellId)
                .HasColumnType("int(11)")
                .HasColumnName("spell_id");

            entity.HasOne(d => d.CharacterClass).WithMany(p => p.DndSpellclasslevels)
                .HasForeignKey(d => d.CharacterClassId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Spell).WithMany(p => p.DndSpellclasslevels)
                .HasForeignKey(d => d.SpellId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndSpelldescriptor1>(entity =>
        {
            entity.ToTable("dnd_spelldescriptor");

            entity.HasIndex(e => e.Slug, "dnd_spelldescriptor_dnd_spelldescriptor_a951d5d6");

            entity.HasIndex(e => e.Name, "dnd_spelldescriptor_dnd_spelldescriptor_name");

            entity.HasIndex(e => e.Slug, "dnd_spelldescriptor_dnd_spelldescriptor_slug_uniq");

            entity.HasIndex(e => e.Name, "dnd_spelldescriptor_name");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("name");
            entity.Property(e => e.Slug)
                .IsRequired()
                .HasColumnType("varchar(64)")
                .HasColumnName("slug");
        });

        modelBuilder.Entity<DndSpelldomainlevel>(entity =>
        {
            entity.ToTable("dnd_spelldomainlevel");

            entity.HasIndex(e => e.SpellId, "dnd_spelldomainlevel_dnd_spelldomainlevel_a091809d");

            entity.HasIndex(e => e.DomainId, "dnd_spelldomainlevel_dnd_spelldomainlevel_a2431ea");

            entity.HasIndex(e => new { e.DomainId, e.SpellId }, "dnd_spelldomainlevel_dnd_spelldomainlevel_domain_id_e7bf8594e3b6bda_uniq");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DomainId)
                .HasColumnType("int(11)")
                .HasColumnName("domain_id");
            entity.Property(e => e.Extra)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("extra");
            entity.Property(e => e.Level)
                .HasColumnType("smallint(5)")
                .HasColumnName("level");
            entity.Property(e => e.SpellId)
                .HasColumnType("int(11)")
                .HasColumnName("spell_id");

            entity.HasOne(d => d.Domain).WithMany(p => p.DndSpelldomainlevels)
                .HasForeignKey(d => d.DomainId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Spell).WithMany(p => p.DndSpelldomainlevels)
                .HasForeignKey(d => d.SpellId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DndSpellschool>(entity =>
        {
            entity.ToTable("dnd_spellschool");

            entity.HasIndex(e => e.Slug, "dnd_spellschool_dnd_spellschool_a951d5d6");

            entity.HasIndex(e => e.Slug, "dnd_spellschool_dnd_spellschool_slug_uniq");

            entity.HasIndex(e => e.Name, "dnd_spellschool_name");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("name");
            entity.Property(e => e.Slug)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("slug");
        });

        modelBuilder.Entity<DndSpellsubschool>(entity =>
        {
            entity.ToTable("dnd_spellsubschool");

            entity.HasIndex(e => e.Slug, "dnd_spellsubschool_dnd_spellsubschool_a951d5d6");

            entity.HasIndex(e => e.Slug, "dnd_spellsubschool_dnd_spellsubschool_slug_uniq");

            entity.HasIndex(e => e.Name, "dnd_spellsubschool_name");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("name");
            entity.Property(e => e.Slug)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("slug");
        });

        modelBuilder.Entity<DndStaticpage>(entity =>
        {
            entity.ToTable("dnd_staticpage");

            entity.HasIndex(e => e.Name, "dnd_staticpage_name");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Body)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("body");
            entity.Property(e => e.BodyHtml)
                .IsRequired()
                .HasColumnType("longtext")
                .HasColumnName("body_html");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(32)")
                .HasColumnName("name");
        });

        modelBuilder.Entity<DndTextfeatprerequisite>(entity =>
        {
            entity.ToTable("dnd_textfeatprerequisite");

            entity.HasIndex(e => e.FeatId, "dnd_textfeatprerequisite_dnd_textfeatprerequisite_2f59e7d8");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.FeatId)
                .HasColumnType("int(11)")
                .HasColumnName("feat_id");
            entity.Property(e => e.Text)
                .IsRequired()
                .HasColumnType("varchar(256)")
                .HasColumnName("text");

            entity.HasOne(d => d.Feat).WithMany(p => p.DndTextfeatprerequisites)
                .HasForeignKey(d => d.FeatId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
