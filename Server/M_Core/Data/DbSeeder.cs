using System.Collections.Generic;
using System.Linq;
using M_Data.models;
using M_Data.Models;

namespace M_Core.Data
{
   public class DbSeeder
   {
       // Make one at a time by commenting some, so we can match the ids
       public static void SeedExperiences(DataContext context)
       {
           if (!context.ExperienceCategories.Any())
           {
              var categories = new List<ExperienceCategory>
               {
                   new ExperienceCategory { Name = "Svangreomsorg for kvinder med komplikationer" },
                   new ExperienceCategory { EUCount = 100, Name = "Svangreomsorg generelt" },
                   new ExperienceCategory { Name = "Anden svangreomsorg" },
                   new ExperienceCategory { Name = "Fødselsomsorg generelt" },
                   new ExperienceCategory { Name = "Fødselsomsorg for kvinder med komplikationer" },
                   new ExperienceCategory { Name = "Anden fødselsomsorg" },
                   new ExperienceCategory { Name = "Barselsomsorg generelt " },
                   new ExperienceCategory { Name = "Barselsomsorg for kvinder med komplikationer" },
                   new ExperienceCategory { Name = "Anden barselsomsorg" },
                   new ExperienceCategory { Name = "Omsorg for nyfødt med komplikationer" },
                   new ExperienceCategory { Name = "Omsorg for kvinder med gynækologiske komplikationer" },
                   new ExperienceCategory { Name = "Intensiv omsorg for kvinder med obstetriske og gynækologiske komplikationer" }
               };
              context.AddRange(categories);
              context.SaveChanges();
           }

           if (!context.Experiences.Any())
           {
              var SvangreomsorGenerelt = context.ExperienceCategories.Single(e => e.Id == 2);
              var AndenSvangreomsorg = context.ExperienceCategories.Single(e => e.Id == 3);
              var FødselsomsorgGenerelt = context.ExperienceCategories.Single(e => e.Id == 4);
              var AndenFødselsomsorg = context.ExperienceCategories.Single(e => e.Id == 6);
              var BarselsomsorgGenerelt = context.ExperienceCategories.Single(e => e.Id == 7);
              var AndenBarselsomsorg = context.ExperienceCategories.Single(e => e.Id == 9);

              var groups = new List<ExperienceGroup>
                 {
                     new ExperienceGroup { Name = "Fødsel" },
                     new ExperienceGroup { Name = "Konsultation" },
                     new ExperienceGroup { Name = "Modtagelse af familie" },
                     new ExperienceGroup { Name = "udføre udvendig undersøgelse" }
                 };

               var experiences = new List<Experience>
               {
                   //Svangreomsorg generelt
                   new Experience { ExperienceCategory = SvangreomsorGenerelt, EU = true, Name = "optage anamnese", Semester = 2,  },
                   new Experience { ExperienceCategory = SvangreomsorGenerelt, EU = true, Name = "identificere ressourcer og belastninger hos kvinden/familien", Semester = 2 },
                   new Experience { ExperienceCategory = SvangreomsorGenerelt, EU = true, Name = "inddrage viden om kvinden/familiens mål og behov i omsorgen", Semester = 2 },
                   new Experience { ExperienceCategory = SvangreomsorGenerelt, EU = true, Name = "samtale om erfaringer med og forventninger til amning", Semester = 2 },
                   new Experience { ExperienceCategory = SvangreomsorGenerelt, EU = true, Name = "samtale om livsstil i graviditeten, herunder KRAM", Semester = 2 },
                   new Experience { ExperienceCategory = SvangreomsorGenerelt, EU = true, Name = "samtale om forventninger til familiedannelsesprocessen", Semester = 2 },
                   new Experience { ExperienceCategory = SvangreomsorGenerelt, EU = true, Name = "samtale om forventning til fødslen", Semester = 2 },
                   new Experience { ExperienceCategory = SvangreomsorGenerelt, EU = true, Name = "samtale om forventning til efterfødselsperioden", Semester = 2 },
                   new Experience { ExperienceCategory = SvangreomsorGenerelt, EU = true, Name = "udføre udvendig undersøgelse - inspektion", Semester = 2 },
                   new Experience { ExperienceCategory = SvangreomsorGenerelt, EU = true, Name = "udføre udvendig undersøgelse - palpation", Semester = 2 },
                   new Experience { ExperienceCategory = SvangreomsorGenerelt, EU = true, Name = "udføre udvendig undersøgelse - auskultation", Semester = 2 },
                   new Experience { ExperienceCategory = SvangreomsorGenerelt, EU = true, Name = "lytte hjertelyd med træstetoskop", Semester = 2 },
                   new Experience { ExperienceCategory = SvangreomsorGenerelt, EU = true, Name = "måle BT og puls", Semester = 2 },
                   new Experience { ExperienceCategory = SvangreomsorGenerelt, EU = true, Name = "foretage urin undersøgelse", Semester = 2 },
                   new Experience { ExperienceCategory = SvangreomsorGenerelt, EU = true, Name = "observere vægt, højde og udregne BMI", Semester = 2 },

                   //Anden svangreomsorg
                   new Experience { ExperienceCategory = AndenSvangreomsorg, EU = false, Name = "tværfagligt samarbejde", Semester = 2,  },
                   new Experience { ExperienceCategory = AndenSvangreomsorg, EU = false, Name = "hjemmebesøg i graviditeten", Semester = 2 },
                   new Experience { ExperienceCategory = AndenSvangreomsorg, EU = false, Name = "forældre– og fødselsforberedende undervisning", Semester = 2 },
                   new Experience { ExperienceCategory = AndenSvangreomsorg, EU = false, Name = "rundvisning på fødeafdelingen ", Semester = 2 },
                   new Experience { ExperienceCategory = AndenSvangreomsorg, EU = false, Name = "efterfødselssamtale", Semester = 2 },
                   new Experience { ExperienceCategory = AndenSvangreomsorg, EU = false, Name = "ultralydsskanning", Semester = 2 },
                   new Experience { ExperienceCategory = AndenSvangreomsorg, EU = false, Name = "journalføre svangreomsorg", Semester = 2 },

                   ////Fødselsomsorg generelt
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "telefonsamtale med fødende", Semester = 2,  },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "modtagelse af kvinde/par i fødsel, herunder", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "samtale om kvinden og partnerens forventninger til fødslen", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "optage anamnese", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "udvendig undersøgelse", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "palpere veer, evt. føre ve-skema", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "4. håndgreb før vaginal eksploration", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "vaginaleksplorere", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "måle BT og puls", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "urinundersøgelse", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "temperaturmåling", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "vejlede om og administration af lavement", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "observere kvindens almene tilstand", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "observere og vejlede den fødende i ve-arbejdet", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "støtte kvinden i vejrtrækning og afspænding", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "vejlede om ikke medicinsk smertelindring", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "inddrage partneren", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "observere fosterhjertelyd med træstetoskop i aktiv fase", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "observere fosterhjertelyd med træstetoskop i presseperioden", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "observere fosterhjertelyd med doptone i aktiv fase", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "observere fosterhjertelyd med doptone i presseperioden", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "klassificere en ukompliceret CTG", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "observere tegnblødning", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "observere vandafgang", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "vurdere behov for, informere om og udføre hindesprængning ", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "støtte til mobilisering", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "være opmærksom på vandladning", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "vurdere behov for, informere om og udføre kateterisation af kvinden", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "observere og vejlede i fødestilling", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "gøre parat til fødsel og dække fødebord", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "vejlede i presseteknik", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "at observere fødslen", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = true, EUCount = 40, Name = "Fødselsomsorg (uden at anvende håndgreb til modtagelse af barnet)", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = true, EUCount = 40, Name = "Fødselsomsorg (ved at anvende håndgreb til modtagelse af barnet)", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = true, EUCount = 40, Name = "Jordemoderfaglig omsorg ved risikoforløb, (fx kvinder med præeklampsi, diabetes mm)", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "fødsel i hjemmet", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "afnavle barn", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "tage blodprøver fra navlesnoren", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "modtage placenta", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "undersøge, vurdere og evt. præsentere placenta", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "inspicere fødselsvejen", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "vurdere Apgar-score", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "vejledede i personlig hygiejne efter fødslen", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "støtte kvinden ved den første amning", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "støtte til etablering af mor/far/barn kontakt", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = false, Name = "deltage i tværprofessionelt samarbejde", Semester = 2 },
                   new Experience { ExperienceCategory = FødselsomsorgGenerelt, EU = true, EUCount = 100, Name = "1-2 timer post partum omsorg for mor og barn ", Semester = 2 },

                   ////Anden fødselsomsorg
                   new Experience { ExperienceCategory = AndenFødselsomsorg, EU = false, Name = "tværfagligt samarbejde", Semester = 2 },
                   new Experience { ExperienceCategory = AndenFødselsomsorg, EU = false, Name = "gennemgå hjemmefødetaske", Semester = 2 },
                   new Experience { ExperienceCategory = AndenFødselsomsorg, EU = false, Name = "fødsel i hjemmet", Semester = 2 },
                   new Experience { ExperienceCategory = AndenFødselsomsorg, EU = false, Name = "journalføre fødsel", Semester = 2 },
                   new Experience { ExperienceCategory = AndenFødselsomsorg, EU = false, Name = "udfylde fødselsregistrering/-anmeldelser", Semester = 2 },
                   new Experience { ExperienceCategory = AndenFødselsomsorg, EU = false, Name = "rapportgivning ved vagtskifte eller ved overflytning til barselsafsnit", Semester = 2 },

                   ////Barselsomsorg generelt
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = true, EUCount = 100, Name = "Barselsomsorg for mor og barn (fx på barselsafsnit, ved efterfødselspakker mm)", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "vejlede kvinden/parret ved udskrivelse til hjemmet fra fødeafsnit", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "at modtage familien på barselsafsnit", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "telefonsamtale med barselfamilie", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "hjemmebesøg efter fødslen", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "barselbesøg på afdeling", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "efterfødselssamtale", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "observere og understøtte tilknytning og familiedannelse", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "vejlede i psykologiske og fysiologiske forandringer post partum", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "observere og vejlede om bristning og episiotomi, herunder vurdere helingen", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "palpere uterus post partum", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "observere og vejlede omkring lokkier", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "være opmærksom på mors vandladning", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "give orientering om og vejledning i knibeøvelser", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "observere og vejlede om amning og ammeteknik", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "observere og vejlede ved brystspænding", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "vejlede om forebyggelse og pleje af ømme papiller", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "vejlede omkring papiller med fissurer", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "observere og vejlede omkring mastitis", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "vejlede i udmalkning manuelt, brystpumpe, håndpumpe", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "vejlede i udmalkning manuelt, brystpumpe, håndpumpe", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "vejlede kvinde, der ikke ønsker at amme", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "vejlede om modermælkserstatning", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "vejlede brystopererede kvinder om amning", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "vejlede om søskende dynamik", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "samtale om sex og samliv efter fødslen herunder prævention", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "vejlede om barnets behov/signaler", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "vejlede om spædbarnspleje", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "informere om og udføre PKU", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "informere om og udføre hørescreening", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "vejlede om icterus", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "vejlede om fødselssvulst og cephalhæmatom", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "give rapport ved vagtskifte", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "afholde udskrivningssamtaler", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "udlevere relevant informationsmateriale", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "journalføre barselsomsorgen", Semester = 2 },
                   new Experience { ExperienceCategory = BarselsomsorgGenerelt, EU = false, Name = "deltage i tværprofessionelt samarbejde", Semester = 2 },

                   ////Anden barselsomsorg
                   new Experience { ExperienceCategory = AndenBarselsomsorg, EU = false, Name = "tværfagligt samarbejde", Semester = 2 },
                   new Experience { ExperienceCategory = AndenBarselsomsorg, EU = false, Name = "Gennemgå medicinskab og organiseringen af dette", Semester = 2 },
                   new Experience { ExperienceCategory = AndenBarselsomsorg, EU = false, Name = "Deltage i kvalitetssikringsarbejde i afdelingen", Semester = 2 },

               };
               context.AddRange(groups);
               context.AddRange(experiences);

                context.AddRange(
                new ExperienceGroupRelation { Experience = experiences[0], ExperienceGroup = groups[0] },
                new ExperienceGroupRelation { Experience = experiences[0], ExperienceGroup = groups[1] },
                new ExperienceGroupRelation { Experience = experiences[1], ExperienceGroup = groups[2] },
                new ExperienceGroupRelation { Experience = experiences[1], ExperienceGroup = groups[3] },
                new ExperienceGroupRelation { Experience = experiences[2], ExperienceGroup = groups[0] },
                new ExperienceGroupRelation { Experience = experiences[2], ExperienceGroup = groups[1] },
                new ExperienceGroupRelation { Experience = experiences[2], ExperienceGroup = groups[2] },
                new ExperienceGroupRelation { Experience = experiences[2], ExperienceGroup = groups[3] });

               context.SaveChanges();
           }

       }
   }
}