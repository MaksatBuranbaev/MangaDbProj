

using Microsoft.EntityFrameworkCore;
using Proj1.Data;

namespace Proj1.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Proj1Context
                (serviceProvider.GetRequiredService<DbContextOptions<Proj1Context>>()))
            {
                if(context.Manga.Any())
                {
                    return;
                }
                context.Manga.AddRange(
                    new Manga
                    {
                        Name = "Berserk",
                        Author = "Kentaro Miura",
                        Illustrator = "Kentaro Miura",
                        Description = "Berserk (Japanese: ベルセルク, Hepburn: Beruseruku) is a Japanese manga series written and illustrated by Kentaro Miura. Set in a medieval Europe-inspired dark fantasy world, the story centers on the characters of Guts, a lone swordsman, and Griffith, the leader of a mercenary band called the \"Band of the Hawk\". The series follows Guts' journey seeking revenge on Griffith, who betrayed him and sacrificed his comrades to become a powerful demonic being.",
                        RealeseDate = DateTime.Parse("1989-8-25"),
                        Genre = "Dark fantasy, Epic fantasy, Sword and sorcery"
                    },
                    new Manga
                    {
                        Name = "Vagabond",
                        Author = "Takehiko Inoue",
                        Illustrator = "Takehiko Inoue",
                        Description = "Vagabond (Japanese: バガボンド, Hepburn: Bagabondo) is a Japanese epic martial arts manga series written and illustrated by Takehiko Inoue. It portrays a fictionalized account of the life of Japanese swordsman Musashi Miyamoto, based on Eiji Yoshikawa's novel Musashi. It has been serialized in Kodansha's seinen manga magazine Morning since September 1998, with its chapters collected in 37 tankōbon volumes by July 2014. Viz Media licensed the series for English release in North America and has published the 37 volumes by April 2015. The series has been on indefinite hiatus since May 2015.",
                        RealeseDate = DateTime.Parse("1998-9-3"),
                        Genre = "Epic, Historical, Martial arts"
                    },
                    new Manga
                    {
                        Name = "Vinland Saga",
                        Author = "Makoto Yukimura",
                        Illustrator = "Makoto Yukimura",
                        Description = "Vinland Saga (Japanese: ヴィンランド・サガ, Hepburn: Vinrando Saga) is a Japanese historical manga series written and illustrated by Makoto Yukimura. The series is published by Kodansha, and was first serialized in the boys-targeted manga magazine Weekly Shōnen Magazine before moving to Monthly Afternoon, aimed at young adult men. As of June 2024, its chapters have been collected in 28 tankōbon volumes. Vinland Saga has been licensed for English-language publication by Kodansha USA. The story is a dramatization of the story of Thorfinn Karlsefni and his expedition to find Vinland, with the majority of the story covering his fictional counterpart's transition from a bloodthirsty, revenge-filled teenager into a pacifistic young man; juxtaposed against this is the rise to power of King Canute, the journey of his own counterpart directly contrasting with that of Thorfinn's.",
                        RealeseDate = DateTime.Parse("2005-4-13"),
                        Genre = "Epic, Historical, Martial arts"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
