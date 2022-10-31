using FPTBook.Controllers;
using FPTBook.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTBook.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<StoreOwner> StoreOwners { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            PopulateCategory(builder);
            SeedBook(builder);

            //add dữ liệu cho bảng User
            SeedUser(builder);

            //add dữ liệu cho bảng Role
            SeedRole(builder);

            //add dữ liệu cho bảng UserRole
            SeedUserRole(builder);
        }



        private void PopulateCategory(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    CatId = "CAT1",
                    CatName = "Romance",
                    CatDescription = "A romance novel or romantic novel generally refers to a type of genre fiction novel which places its primary focus on the relationship and romantic love between two people, and usually has an \"emotionally satisfying and optimistic ending.\"",
                    Status = 2
                },
                new Category
                {
                    Id = 2,
                    CatId = "CAT2",
                    CatName = "Fiction",
                    CatDescription = "Fiction books are usually novels or short stories and the value of fiction books is all in the imagination, the theme of the work, the generalization of reality and the ideas that make up literature.",
                    Status = 2
                },
                new Category
                {
                    Id = 3,
                    CatId = "CAT3",
                    CatName = "Kids",
                    CatDescription = "Children's literature includes stories, books, magazines, and poems made for children. Modern children's literature is classified in two different ways: by genre or by age group.",
                    Status = 2
                },
                new Category
                {
                    Id = 4,
                    CatId = "CAT4",
                    CatName = "Technology",
                    CatDescription = "Programming books are one of the most treasured resources by developers. A few even see them as proof of the whole journey they have gone through. But the hard part is to invest time wisely in quality programming books.",
                    Status = 2
                }
                );
        }

        private void SeedBook(ModelBuilder builder)
        {
            builder.Entity<Book>().HasData(
              new Book
              {
                  Id = 1,
                  BookId = "B01",
                  BookTitle = "Tweet Cute",
                  BookQuantity = 94,
                  BookPrice = 10.22,
                  BookAuthor = "Emma Lord",
                  BookImage = "https://images-us.bookshop.org/ingram/9781250750433.jpg?height=500&v=v2",
                  BookDescription = "A witty rom-com reinvention ... with deeply relatable insights on family pressure and growing up.\" - Emily Wibberley and Austin Siegemund-Broka, authors of Always Never Yours and If I'm Being Honest\r\n\r\n\"An adorable debut that updates a classic romantic trope with a buzzy twist. - Jenn Bennett, author of Alex, Approximately, and Serious Moonlight\r\nThis a fresh, irresistible rom-com from debut author Emma Lord about the chances we take, the paths life can lead us on, and how love can be found in the opposite place you expected.\r\n",
                  CategoryId = 1
              },
              new Book
              {
                  Id = 2,
                  BookId = "B02",
                  BookTitle = "Melt With You",
                  BookQuantity = 21,
                  BookPrice = 16.73,
                  BookAuthor = "Jennifer Dugan",
                  BookImage = "https://images-us.bookshop.org/ingram/9780593112564.jpg?height=500&v=v2-6b97a15a141839785a16b93bf6703b27",
                  BookDescription = "From the author of Some Girls Do and Hot Dog Girl comes a sweet and salty queer YA rom-com about two girls on a summer road trip in an ice cream truck.\r\nFallon is Type A, looks before she leaps, and always has a plan (and a backup plan).\r\nChloe is happy-go-lucky, flies by the seat of her pants, and always follows her bliss.\r\nThe two girls used to be best friends, but last summer they hooked up right before Chloe left for college, and after a series of misunderstandings, they aren't even speaking to each other.\r\nA year later, Chloe's back home from school, and Fallon is doing everything in her power to avoid her. Which is especially difficult because their moms own a business together--a gourmet ice cream truck where both girls work.\r\nWhen a meeting with some promising potential investors calls their parents away at the last minute, it's up to Fallon to work a series of important food truck festivals across the country. But she can't do it alone, and Chloe is the only one available to help.\r\nTensions heat up again between the two girls as they face a few unexpected detours--and more than a little roadside attraction. But maybe, just maybe, the best things in life can't always be planned.\r\n",
                  CategoryId = 1
              },
              new Book
              {
                  Id = 3,
                  BookId = "B03",
                  BookTitle = "For Butter or Worse",
                  BookQuantity = 8,
                  BookPrice = 14.87,
                  BookAuthor = "Erin La Rosa",
                  BookImage = "https://images-us.bookshop.org/ingram/9781335506344.jpg?height=500&v=v2-8ba8040a09b872c94676149c2e8c599b",
                  BookDescription = "\"With great tension, simmering heat, and clever banter, FOR BUTTER OR WORSE is a mouthwateringly delicious enemies-to-lovers romance.\"--Helen Hoang, USA Today bestselling author of The Heart Principle\r\n\r\n\"[A] sparkling romance...witty and lighthearted, with plenty of tender moments to keep readers invested, this work gets the enemies-to-lovers trope right.\"--Publishers Weekly\r\n\r\nThey go together like water and oil...\r\n",
                  CategoryId = 1
              },
              new Book
              {
                  Id = 4,
                  BookId = "B04",
                  BookTitle = "The Princess Affair",
                  BookQuantity = 41,
                  BookPrice = 15.76,
                  BookAuthor = "Nell Stark",
                  BookImage = "https://images-us.bookshop.org/ingram/9781602828582.jpg?height=500&v=v2",
                  BookDescription = "Rhodes Scholar Kerry Donovan has never had anything handed to her on a silver platter. As she arrives at Oxford to begin her course of study, she is determined to make the most out of this latest opportunity. But when she meets Her Royal Highness Princess Sasha, second in line to the British throne, Kerry's priorities are eclipsed by an attraction neither of them can ignore. \"Sassy Sasha\" is a tabloid favorite who appears to delight in scandalizing her people, but beneath her vexed public image, Sasha longs to be truly seen.\r\nWill the tenuous connection she forms with Kerry be broken by the weight of the crown? Or will they find true love despite the forces endeavoring to keep them apart?\r\n",
                  CategoryId = 1
              },
              new Book
              {
                  Id = 5,
                  BookId = "B05",
                  BookTitle = "The Royal We",
                  BookQuantity = 29,
                  BookPrice = 15.80,
                  BookAuthor = "Heather Cocks",
                  BookImage = "https://images-us.bookshop.org/ingram/9781455557110.jpg?height=500&v=v2\r\n\r\n \r\n",
                  BookDescription = "An American girl finds her prince in this fun and dishy (People) royal romance inspired by Prince William and Kate Middleton.\r\nAmerican Bex Porter was never one for fairy tales. Her twin sister Lacey was always the romantic, the one who daydreamed of being a princess. But it's adventure-seeking Bex who goes to Oxford and meets dreamy Nick across the hall - and Bex who finds herself accidentally in love with the heir to the British throne.\r\nNick is wonderful, but he comes with unimaginable baggage: a complicated family, hysterical tabloids tracking his every move, and a public that expected its future king to marry a Brit. On the eve of the most talked-about wedding of the century, Bex looks back on how much she's had to give up for true love... and exactly whose heart she may yet have to break.\r\n",
                  CategoryId = 1
              },
              new Book
              {
                  Id = 6,
                  BookId = "B06",
                  BookTitle = "Stand-In",
                  BookQuantity = 73,
                  BookPrice = 13.94,
                  BookAuthor = "Lily Chu",
                  BookImage = "https://images-us.bookshop.org/ingram/9781728242620.jpg?height=500&v=v2",
                  BookDescription = "Featured in USA Today's Best Rom-Coms of May 2023 and one of the Washington Post's best romances of the year!\r\n\r\nGracie Reed was just fired by her overly handsy boss at the worst possible moment. She's been scraping together every extra dollar to get her mother into a top-notch memory care center. To make matters worse, a paparazzo has mistaken her for a famous Chinese actress in town for a new project and the resulting snapshot's gone viral. Gracie's barely holding it all together...until a mysterious SUV rolls up beside her on the street, and she's offered the opportunity of a lifetime.\r\n\r\nGracie can't believe what she's hearing: due to their uncanny resemblance, gorgeous actress Wei Fangli wants Gracie to be her stand-in. The catch? Gracie will have to be escorted by Sam Yao, the other half of Chinese cinema's infamous golden couple. Problem is, Sam is the most attractive--and infuriating--man Gracie's ever met.\r\n\r\nBut if it means getting the money she needs for her mother, Gracie's in. Soon Gracie moves into a world of luxury she never knew existed. But resisting her attraction to Sam, and playing the role of an elegant movie star, proves more difficult than she ever imagined--especially when she learns the real reason Fangli so desperately needs to step out of the spotlight. In the end all the effort in the world won't be able to help Gracie keep up this elaborate ruse without losing herself...and her heart.\r\n",
                  CategoryId = 1
              },
              new Book
              {
                  Id = 7,
                  BookId = "B07",
                  BookTitle = "Tokyo Even After",
                  BookQuantity = 44,
                  BookPrice = 11.15,
                  BookAuthor = "Emiko Jean",
                  BookImage = "https://images-us.bookshop.org/ingram/9781250766601.jpg?height=500&v=v2-83412b070c9880cb286586024d425c19",
                  BookDescription = "Emiko Jean's New York Times bestseller and Reese Book Club Pick Tokyo Ever After is the \"refreshing, spot-on\" (Booklist, starred review) story of an ordinary Japanese American girl who discovers that her father is the Crown Prince of Japan!\r\n\r\nIzumi Tanaka has never really felt like she fit in--it isn't easy being Japanese American in her small, mostly white, northern California town. Raised by a single mother, it's always been Izumi--or Izzy, because \"It's easier this way\"--and her mom against the world. But then Izumi discovers a clue to her previously unknown father's identity...and he's none other than the Crown Prince of Japan. Which means outspoken, irreverent Izzy is literally a princess.\r\nIn a whirlwind, Izumi travels to Japan to meet the father she never knew and discover the country she always dreamed of. But being a princess isn't all ball gowns and tiaras. There are conniving cousins, a hungry press, a scowling but handsome bodyguard who just might be her soulmate, and thousands of years of tradition and customs to learn practically overnight.\r\nIzumi soon finds herself caught between worlds, and between versions of herself--back home, she was never \"American\" enough, and in Japan, she must prove she's \"Japanese\" enough. Will Izumi crumble under the weight of the crown, or will she live out her fairy tale, happily ever after?\r\nLook for the bestselling sequel, Tokyo Dreaming, out now.\r\n",
                  CategoryId = 1
              },
              new Book
              {
                  Id = 8,
                  BookId = "B08",
                  BookTitle = "Verity",
                  BookQuantity = 15,
                  BookPrice = 15.80,
                  BookAuthor = "Colleen Hoover",
                  BookImage = "https://images-us.bookshop.org/ingram/9781538724736.jpg?height=500&v=v2-d5582503aa43f350b03c8d978f17d659",
                  BookDescription = "A \"sublimely creepy\" psychological thriller from #1 New York Times bestselling author Colleen Hoover (Tarryn Fisher, New York Times bestselling author).\r\nLowen Ashleigh is a struggling writer on the brink of financial ruin when she accepts the job offer of a lifetime. Jeremy Crawford, husband of bestselling author Verity Crawford, has hired Lowen to complete the remaining books in a successful series his injured wife is unable to finish.\r\nLowen arrives at the Crawford home, ready to sort through years of Verity's notes and outlines, hoping to find enough material to get her started. What Lowen doesn't expect to uncover in the chaotic office is an unfinished autobiography Verity never intended for anyone to read. Page after page of bone-chilling admissions, including Verity's recollection of the night her family was forever altered.\r\nLowen decides to keep the manuscript hidden from Jeremy, knowing its contents could devastate the already grieving father. But as Lowen's feelings for Jeremy begin to intensify, she recognizes all the ways she could benefit if he were to read his wife's words. After all, no matter how devoted Jeremy is to his injured wife, a truth this horrifying would make it impossible for him to continue loving her.\r\n",
                  CategoryId = 2
              },
              new Book
              {
                  Id = 9,
                  BookId = "B09",
                  BookTitle = "Heart Bones",
                  BookQuantity = 73,
                  BookPrice = 14.99,
                  BookAuthor = "Colleen Hoover ",
                  BookImage = "https://images-us.bookshop.org/ingram/9798671981742.jpg?height=500&v=v2-12ce2f330a447c1d10abfd38543c3f27",
                  BookDescription = "Life and a dismal last name are the only two things Beyah Grim's parents ever gave her. After carving her path all on her own, Beyah is well on her way to bigger and better things, thanks to no one but herself. With only two short months separating her from the future she's built and the past she desperately wants to leave behind, an unexpected death leaves Beyah with no place to go during the interim. Forced to reach out to her last resort, Beyah has to spend the remainder of her summer on a peninsula in Texas with a father she barely knows. Beyah's plan is to keep her head down and let the summer slip by seamlessly, but her new neighbor Samson throws a wrench in that plan. Samson and Beyah have nothing in common on the surface. She comes from a life of poverty and neglect; he comes from a family of wealth and privilege. But one thing they do have in common is that they're both drawn to sad things. Which means they're drawn to each other. With an almost immediate connection too intense for them to continue denying, Beyah and Samson agree to stay in the shallow end of a summer fling. What Beyah doesn't realize is that a rip current is coming, and it's about to drag her heart out to sea. \"This book deserves a whole galaxy of stars, but alas, five is all I can give.\" -Shades of Rebecca",
                  CategoryId = 2
              },
              new Book
              {
                  Id = 10,
                  BookId = "B10",
                  BookTitle = "The Passenger",
                  BookQuantity = 59,
                  BookPrice = 27.90,
                  BookAuthor = "Cormac McCarthy",
                  BookImage = "https://images-us.bookshop.org/ingram/9780307268990.jpg?height=500&v=v2-00406b3bb44913c3f1545cdaafb69311",
                  BookDescription = "The best-selling, Pulitzer Prize-winning author of The Road returns with the first of a two-volume masterpiece: The Passenger is the story of a salvage diver, haunted by loss, afraid of the watery deep, pursued for a conspiracy beyond his understanding, and longing for a death he cannot reconcile with God.\r\nLook for Stella Maris, the second volume in The Passenger series, on sale December 6th, 2022\r\n1980, PASS CHRISTIAN, MISSISSIPPI: It is three in the morning when Bobby Western zips the jacket of his wet suit and plunges from the Coast Guard tender into darkness. His dive light illuminates the sunken jet, nine bodies still buckled in their seats, hair floating, eyes devoid of speculation. Missing from the crash site are the pilot's flight bag, the plane's black box, and the tenth passenger. But how? A collateral witness to machinations that can only bring him harm, Western is shadowed in body and spirit--by men with badges; by the ghost of his father, inventor of the bomb that melted glass and flesh in Hiroshima; and by his sister, the love and ruin of his soul.\r\nTraversing the American South, from the garrulous barrooms of New Orleans to an abandoned oil rig off the Florida coast, The Passenger is a breathtaking novel of morality and science, the legacy of sin, and the madness that is human consciousness.\r\n",
                  CategoryId = 2
              },
              new Book
              {
                  Id = 11,
                  BookId = "B11",
                  BookTitle = "The World We Make",
                  BookQuantity = 79,
                  BookPrice = 27.90,
                  BookAuthor = "N K Jemisin",
                  BookImage = "https://images-us.bookshop.org/ingram/9780316509893.jpg?height=500&v=v2-fcc4196c13b664cfd617f62c7a443ae1",
                  BookDescription = "Four-time Hugo Award-winning and New York Times bestselling author N.K. Jemisin crafts a glorious tale of identity, resistance, magic and myth.\r\n\r\nAll is not well in the city that never sleeps. Even though the avatars of New York City have temporarily managed to stop the Woman in White from invading--and destroying the entire universe in the process--the mysterious capital \"E\" Enemy has more subtle powers at her disposal. A new candidate for mayor wielding the populist rhetoric of gentrification, xenophobia, and \"law and order\" may have what it takes to change the very nature of New York itself and take it down from the inside.\r\nIn order to defeat him, and the Enemy who holds his purse strings, the avatars will have to join together with the other Great Cities of the world in order to bring her down for good and protect their world from complete destruction.\r\nN.K. Jemisin's Great Cities Duology, which began with The City We Became and concludes with The World We Make, is a masterpiece of speculative fiction from one of the most important writers of her generation.\r\n",
                  CategoryId = 2
              },
              new Book
              {
                  Id = 12,
                  BookId = "B12",
                  BookTitle = "Happening",
                  BookQuantity = 16,
                  BookPrice = 14.95,
                  BookAuthor = "Annie Ernaux",
                  BookImage = "https://images-us.bookshop.org/ingram/9781609809485.jpg?height=500&v=v2-5b6c1e612fc69a31babc05fbba0320cb",
                  BookDescription = "WINNER OF THE 2022 NOBEL PRIZE IN LITERATURE\r\nHappening recounts what it was like to be a young woman whose life changed -- and world ominously narrowed -- in 1963 with an unwanted pregnancy. . . . It feels urgently of the moment.\r\n--The New York Times\r\nIn 1963, Annie Ernaux, 23 and unattached, realizes she is pregnant. Shame arises in her like a plague: Understanding that her pregnancy will mark her and her family as social failures, she knows she cannot keep that child.\r\nThis is the story, written forty years later, of a trauma Ernaux never overcame. In a France where abortion was illegal, she attempted, in vain, to self-administer the abortion with a knitting needle. Fearful and desperate, she finally located an abortionist, and ends up in a hospital emergency ward where she nearly dies.\r\nIn Happening, Ernaux sifts through her memories and her journal entries dating from those days. Clearly, cleanly, she gleans the meanings of her experience.\r\nNow an award-winning film by Audrey Diwan\r\nWinner of the Golden Lion at the Venice International Film Festival\r\nOfficial Selection of the Sundance Film Festival\r\n",
                  CategoryId = 2
              },
              new Book
              {
                  Id = 13,
                  BookId = "B13",
                  BookTitle = "Nona the Ninth",
                  BookQuantity = 75,
                  BookPrice = 26.96,
                  BookAuthor = "Tamsyn Muir",
                  BookImage = "https://images-us.bookshop.org/ingram/9781250854117.jpg?height=500&v=v2-94cf28e97c5bb2bf10aaa48ca4d6731c",
                  BookDescription = "Her city is under siege.\r\nThe zombies are coming back.\r\nAnd all Nona wants is a birthday party.\r\nIn many ways, Nona is like other people. She lives with her family, has a job at her local school, and loves walks on the beach and meeting new dogs. But Nona's not like other people. Six months ago she woke up in a stranger's body, and she's afraid she might have to give it back.\r\nThe whole city is falling to pieces. A monstrous blue sphere hangs on the horizon, ready to tear the planet apart. Blood of Eden forces have surrounded the last Cohort facility and wait for the Emperor Undying to come calling. Their leaders want Nona to be the weapon that will save them from the Nine Houses. Nona would prefer to live an ordinary life with the people she loves, with Pyrrha and Camilla and Palamedes, but she also knows that nothing lasts forever.\r\nAnd each night, Nona dreams of a woman with a skull-painted face...\r\n",
                  CategoryId = 2
              },
              new Book
              {
                  Id = 14,
                  BookId = "B14",
                  BookTitle = "Gideon the Ninth",
                  BookQuantity = 49,
                  BookPrice = 16.73,
                  BookAuthor = "Tamsyn Muir",
                  BookImage = "https://images-us.bookshop.org/ingram/9781250313188.jpg?height=500&v=v2",
                  BookDescription = "The Emperor needs necromancers.\r\nThe Ninth Necromancer needs a swordswoman.\r\nGideon has a sword, some dirty magazines, and no more time for undead nonsense.\r\nTamsyn Muir's Gideon the Ninth, first in The Locked Tomb Trilogy, unveils a solar system of swordplay, cut-throat politics, and lesbian necromancers. Her characters leap off the page, as skillfully animated as arcane revenants. The result is a heart-pounding epic science fantasy.\r\nBrought up by unfriendly, ossifying nuns, ancient retainers, and countless skeletons, Gideon is ready to abandon a life of servitude and an afterlife as a reanimated corpse. She packs up her sword, her shoes, and her dirty magazines, and prepares to launch her daring escape. But her childhood nemesis won't set her free without a service.\r\nHarrowhark Nonagesimus, Reverend Daughter of the Ninth House and bone witch extraordinaire, has been summoned into action. The Emperor has invited the heirs to each of his loyal Houses to a deadly trial of wits and skill. If Harrowhark succeeds she will be become an immortal, all-powerful servant of the Resurrection, but no necromancer can ascend without their cavalier. Without Gideon's sword, Harrow will fail, and the Ninth House will die.\r\n",
                  CategoryId = 2
              },
              new Book
              {
                  Id = 15,
                  BookId = "B15",
                  BookTitle = "Fairy Tale",
                  BookQuantity = 68,
                  BookPrice = 30.23,
                  BookAuthor = "Stephen King",
                  BookImage = "https://images-us.bookshop.org/ingram/9781668002179.jpg?height=500&v=v2-4fc57ef90d89b8fbcdd565883da4ef63",
                  BookDescription = "Legendary storyteller Stephen King goes into the deepest well of his imagination in this spellbinding novel about a seventeen-year-old boy who inherits the keys to a parallel world where good and evil are at war, and the stakes could not be higher--for that world or ours.\r\nCharlie Reade looks like a regular high school kid, great at baseball and football, a decent student. But he carries a heavy load. His mom was killed in a hit-and-run accident when he was seven, and grief drove his dad to drink. Charlie learned how to take care of himself--and his dad. When Charlie is seventeen, he meets a dog named Radar and her aging master, Howard Bowditch, a recluse in a big house at the top of a big hill, with a locked shed in the backyard. Sometimes strange sounds emerge from it.\r\nCharlie starts doing jobs for Mr. Bowditch and loses his heart to Radar. Then, when Bowditch dies, he leaves Charlie a cassette tape telling a story no one would believe. What Bowditch knows, and has kept secret all his long life, is that inside the shed is a portal to another world.\r\n",
                  CategoryId = 2
              },
              new Book
              {
                  Id = 16,
                  BookId = "B16",
                  BookTitle = "Goodnight, Little Panda",
                  BookQuantity = 1,
                  BookPrice = 12.08,
                  BookAuthor = "Amanda Wood",
                  BookImage = "https://images-us.bookshop.org/ingram/9781419751578.jpg?height=500&v=v2",
                  BookDescription = "Perfect for bedtime or naptime, this simple story about a picky eater will soothe your little one to sleep\r\nLittle Panda won't eat her dinner. It's much too munchy and crunchy! But when the other animals offer to share their food with her, she starts to think that perhaps bamboo isn't so bad after all . . . Featuring a unique blend of photos and illustrations, this adorable book is perfect for bedtime or naptime and is sure to give your little one sweet dreams.\r\n",
                  CategoryId = 3
              },
              new Book
              {
                  Id = 17,
                  BookId = "B17",
                  BookTitle = "Night Night, Dino-Snores",
                  BookQuantity = 17,
                  BookPrice = 12.08,
                  BookAuthor = "Nicola Edwards",
                  BookImage = "https://images-us.bookshop.org/ingram/9781680105483.jpg?height=500&v=v2",
                  BookDescription = "Snuggle up with Sleepy Stegosaurus and his dinosaur friends for a gentle bedtime read with rhyming text, a variety of touch-and-feel textures, and charming illustrations.\r\nSay good night to the dinosaurs as they settle down to sleep in this gentle bedtime read with rhyming text. A tiny and tired T-rex enjoys a ride home on Mom's back; sleepy Stegosauruses look for a comfortable place to lie down; and the Diplodocuses curl up on the ground after spending the day munching leaves. As the stars twinkle in the dark sky, all of the dinosaurs fall asleep. Includes touch-and-feel elements throughout the book and one on the cover!\r\n",
                  CategoryId = 3
              },
              new Book
              {
                  Id = 18,
                  BookId = "B18",
                  BookTitle = "A-Okay",
                  BookQuantity = 5,
                  BookPrice = 12.08,
                  BookAuthor = "Jarad Greene",
                  BookImage = "https://images-us.bookshop.org/ingram/9780063032859.jpg?height=500&v=v2",
                  BookDescription = "A-Okay by Jarad Greene is a vulnerable and heartfelt semi-autobiographical middle grade graphic novel about acne, identity, and finding your place.\r\n\r\nWhen Jay starts eighth grade with a few pimples he doesn't think much of it at first...except to wonder if the embarrassing acne will disappear as quickly as it arrived. But when his acne goes from bad to worse, Jay's prescribed a powerful medication that comes with some serious side effects. Regardless, he's convinced it'll all be worth it if clear skin is on the horizon!\r\n\r\nMeanwhile, school isn't going exactly as planned. All of Jay's friends are in different classes; he has no one to sit with at lunch; his best friend, Brace, is avoiding him; and--to top it off--Jay doesn't understand why he doesn't share the same feelings two of his fellow classmates, a boy named Mark and a girl named Amy, have for him.\r\n\r\nEighth grade can be tough, but Jay has to believe everything's going to be a-okay...right?\r\n",
                  CategoryId = 3
              },
              new Book
              {
                  Id = 19,
                  BookId = "B19",
                  BookTitle = "Maud and Grand-Maud",
                  BookQuantity = 38,
                  BookPrice = 16.73,
                  BookAuthor = "Sara O’Leary",
                  BookImage = "https://images-us.bookshop.org/ingram/9780399554582.jpg?height=500&v=v2",
                  BookDescription = "This sweet story captures the singular experience of a visit with Grandma, especially when you share a name - a perfect gift for Mother's Day!\r\nHere is a celebration of the unique bond between grandparents and grandchildren. Maud loves the weekends when she stays at her grandma's house. There's always breakfast for supper, matching nightgowns, black-and-white movies, and--best of all--someone to listen to her dreams for her life as a grown-up. But what makes the visits extra special is what Grand-Maud has hidden in an old chest under Maud's bed. She may find a paint set, a toy, homemade cookies, or hand-knit mittens or sweaters. Best of all is when Maud finds something that belonged to Grand-Maud when she was a little girl. In this story of family togetherness, Maud wants to be just like Grand-Maud when she grows up.\r\n",
                  CategoryId = 3
              },
              new Book
              {
                  Id = 20,
                  BookId = "B20",
                  BookTitle = "Chicken Sunday",
                  BookQuantity = 62,
                  BookPrice = 7.43,
                  BookAuthor = "Patricia Polacco",
                  BookImage = "https://images-us.bookshop.org/ingram/9780698116153.jpg?height=500&v=v2",
                  BookDescription = "After being initiated into a neighbor's family by a solemn backyard ceremony, a young Russian American girl and her African American brothers' determine to buy their gramma Eula a beautiful Easter hat. But their good intentions are misunderstood, until they discover just the right way to pay for the hat that Eula's had her eye on. A loving family story woven from the author's childhood.",
                  CategoryId = 3
              },
              new Book
              {
                  Id = 21,
                  BookId = "B21",
                  BookTitle = "The Witchling’s Wish",
                  BookQuantity = 34,
                  BookPrice = 16.73,
                  BookAuthor = "Lu Fraser",
                  BookImage = "https://images-us.bookshop.org/ingram/9781547609062.jpg?height=500&v=v2-9a4f5609a36906ec61c67b9a7184d323",
                  BookDescription = "From the illustrator of The Girl and The Dinosaur comes a heartwarming, magical picture book about what it means to be a friend.\r\n\r\nLittle Witchling lives alone on her mountain top, and more than anything else, she wishes for a friend. When her spell book tells her that the secret ingredient to conjuring a friend is the fur from a little girl's favorite teddy bear, she knows what she must do.\r\nBut the bear belongs to Lily, who can't bear to part with him. Will the Little Witchling give up her dream of a real friend? Or maybe there's a way for her and Lily to make the wish come true together . . .\r\nWith heartwarming rhyming text from Lu Fraser, and beautiful illustrations from Sarah Massini, this magical friendship story is perfect for little witches everywhere!\r\n",
                  CategoryId = 3
              },
              new Book
              {
                  Id = 22,
                  BookId = "B22",
                  BookTitle = "Stumpkin",
                  BookQuantity = 74,
                  BookPrice = 16.73,
                  BookAuthor = "Lucy Ruth Cummins",
                  BookImage = "https://images-us.bookshop.org/ingram/9781534413627.jpg?height=500&v=v2",
                  BookDescription = "From the critically acclaimed author and illustrator of A Hungry Lion comes a unique Halloween story about a stemless pumpkin who dreams of becoming a jack-o-lantern.\r\nStumpkin is the most handsome pumpkin on the block. He's as orange as a traffic cone! Twice as round as a basketball! He has no bad side! He's perfect choice for a Halloween jack-o-lantern.\r\nThere's just one problem--Stumpkin has a stump, not a stem. And no one seems to want a stemless jack-o-lantern for their window.\r\nAs Halloween night approaches, more and more of his fellow pumpkins leave, but poor Stumpkin remains. Will anyone give Stumpkin his chance to shine?\r\n",
                  CategoryId = 3
              },
              new Book
              {
                  Id = 23,
                  BookId = "B23",
                  BookTitle = "Oscar Seeks a Friend",
                  BookQuantity = 10,
                  BookPrice = 8.36,
                  BookAuthor = "Pawel Pawlak",
                  BookImage = "https://images-us.bookshop.org/ingram/9781915244079.jpg?height=500&v=v2-3e8fe8db7ef3466917a32a7c1e72ce31",
                  BookDescription = "What if you could turn the world the other way around and take a peek at what's on the other side?\r\n\r\nPerhaps if you did, you would find something you never expected. Such as friendship. When Oscar meets a lonely little girl, it's the start of an adventure for both of them. Together they make an unusual journey to two very different worlds, each beautiful and necessary. And it all begins when the little girl's tooth falls out...\r\n\r\nTranslated from Polish by award-winning translator Antonia Lloyd-Jones.\r\n\r\n\"Color and composition combine to beautifully express friendship and the wonders of the world\"--Kirkus Reviews, STARRED\r\n\r\n\"A delightfully unique and heartwarming story about friendship\"--School Library Journal\r\n",
                  CategoryId = 3
              },
              new Book
              {
                  Id = 24,
                  BookId = "B24",
                  BookTitle = "The Scariest Book Ever",
                  BookQuantity = 52,
                  BookPrice = 16.73,
                  BookAuthor = "Bob Shea",
                  BookImage = "https://images-us.bookshop.org/ingram/9781484730461.jpg?height=500&v=v2",
                  BookDescription = "A silly (and actually not TOO scary ) story perfect for Halloween read-alouds, from favorite funny man Bob Shea \"A delight for kids who have graduated from Herv Tullet's work and such classics as There's a Monster at the End of This Book.\" -- Kirkus Reviews\r\nReader beware This is the scariest book ever Or so claims its melodramatic ghost narrator. Go ahead and turn the page, but don't expect him to come with you. Anything might pop out of that black hole in the middle of the forest What do you mean, it's just a bunny? Well, it's probably a bunny with big fangs Despite the ghost's fear-mongering, none of the animal characters seem very scary at all.... What's up with that?\r\nMany delights -- such as surprises after the page turns, a wildly over-the-top narrator, and perfect punch lines for readers to anticipate -- make this book a scream for both kids and parents.\r\nDon't miss The Happiest Book Ever, also by Bob Shea\r\n.",
                  CategoryId = 3
              },
              new Book
              {
                  Id = 25,
                  BookId = "B25",
                  BookTitle = "Coutdown to Halloween",
                  BookQuantity = 23,
                  BookPrice = 12.08,
                  BookAuthor = "Greg Paprocki",
                  BookImage = "https://images-us.bookshop.org/ingram/9781423661436.jpg?height=500&v=v2-5292ec089850a4aaf2549772260322ce",
                  BookDescription = "Brimming with Halloween excitement, each spread of this charming primer invites toddlers to find and count objects hidden in just-spooky-enough scenes of fall fun.\r\n\r\nHalloween is coming! Toddlers learn to count down from 10 by finding objects hidden throughout these charming scenes of fall fun rendered in illustrator Greg Paprocki's classically retro midcentury art style. From walking through corn mazes and bobbing for apples to choosing costumes and telling spooky stories around a fire, there's excitement on every page. The final spread is packed with surprises! Discover new details in each illustration with every successive reading.\r\n",
                  CategoryId = 3
              },
              new Book
              {
                  Id = 26,
                  BookId = "B26",
                  BookTitle = "Ghoulia",
                  BookQuantity = 47,
                  BookPrice = 9.29,
                  BookAuthor = "Barbara Cantini",
                  BookImage = "https://images-us.bookshop.org/ingram/9781419732935.jpg?height=500&v=v2",
                  BookDescription = "Ghoulia lives in Crumbling Manor with her Auntie Departed and spends most of her time playing with Tragedy, her beloved albino greyhound. But things aren't as easy as they seem for this little zombie girl--all she wants is a real friend. She tries to venture past the manor's walls, but she can't hide her pale green skin or the deep purple circles under her eyes. The other children will be afraid of her, and no one will want to be her friend. But when Halloween rolls around, Ghoulia hatches a brilliant plan. All the other, ordinary children will be dressed up like monsters, so Ghoulia can go out into the town and be entirely herself. In the end, all the kids realize that Ghoulia is (almost) just like them and learn that friendship can come in many forms.",
                  CategoryId = 3
              },
              new Book
              {
                  Id = 27,
                  BookId = "B27",
                  BookTitle = "Gustavo, the Shy Ghost",
                  BookQuantity = 91,
                  BookPrice = 16.73,
                  BookAuthor = "Flavia Z. Drago",
                  BookImage = "https://images-us.bookshop.org/ingram/9781536211146.jpg?height=500&v=v2",
                  BookDescription = "A #1 New York Times bestseller!\r\nThis winning debut picture book from Mexican artist Flavia Z. Drago about finding the courage to make friends is perfect for the spooky season -- or anytime.\r\nGustavo is good at doing all sorts of ghostly things: walking through walls, making objects fly, and glowing in the dark. And he loves almost nothing more than playing beautiful music on his violin. But Gustavo is shy, and some things are harder for him to do, like getting in a line to buy eye scream or making friends with other monsters. Whenever he tries getting close to them, he realizes they just can't see him. Now that the Day of the Dead is fast approaching, what can he do to make them notice him and to share with them something he loves? With fancifully detailed artwork and visual humor, debut picture-book creator Flavia Z. Drago's vivid illustrations tell a sweet and gently offbeat story of loneliness, bravery, and friendship that is sure to be a treat for little ghouls and goblins everywhere.\r\n",
                  CategoryId = 3
              },
              new Book
              {
                  Id = 28,
                  BookId = "B28",
                  BookTitle = "Once Upon an Algorithm",
                  BookQuantity = 95,
                  BookPrice = 21.14,
                  BookAuthor = "Martin Erwig",
                  BookImage = "https://m.media-amazon.com/images/I/51idThhbpqL.jpg",
                  BookDescription = "This easy-to-follow introduction to computer science reveals how familiar stories like Hansel and Gretel, Sherlock Holmes, and Harry Potter illustrate the concepts and everyday relevance of computing.\r\n\r\nPicture a computer scientist, staring at a screen and clicking away frantically on a keyboard, hacking into a system, or perhaps developing an app. Now delete that picture. In Once Upon an Algorithm, Martin Erwig explains computation as something that takes place beyond electronic computers, and computer science as the study of systematic problem solving. Erwig points out that many daily activities involve problem solving. Getting up in the morning, for example: You get up, take a shower, get dressed, eat breakfast. This simple daily routine solves a recurring problem through a series of well-defined steps. In computer science, such a routine is called an algorithm.\r\n",
                  CategoryId = 4
              },
              new Book
              {
                  Id = 29,
                  BookId = "B29",
                  BookTitle = "System Design Interview",
                  BookQuantity = 58,
                  BookPrice = 35.99,
                  BookAuthor = "Alex Xu",
                  BookImage = "https://m.media-amazon.com/images/I/312L17hmrOL._SX331_BO1,204,203,200_.jpg",
                  BookDescription = "System Design Interview - An Insider's Guide (Volume 1)\r\n\r\nSystem design interviews are the most difficult to tackle of all technical interview questions. This book is Volume 1 of the System Design Interview - An insider’s guide series that provides a reliable strategy and knowledge base for approaching a broad range of system design questions. This book provides a step-by-step framework for how to tackle a system design question. It includes many real-world examples to illustrate the systematic approach, with detailed steps that you can follow.\r\n\r\nWhat’s inside?\r\n- An insider’s take on what interviewers really look for and why.\r\n- A 4-step framework for solving any system design interview question.\r\n- 16 real system design interview questions with detailed solutions.\r\n- 188 diagrams to visually explain how different systems work\r\n",
                  CategoryId = 4
              },
              new Book
              {
                  Id = 30,
                  BookId = "B30",
                  BookTitle = "The Youtube Formula",
                  BookQuantity = 37,
                  BookPrice = 16.29,
                  BookAuthor = "Derral Eves",
                  BookImage = "https://m.media-amazon.com/images/I/51Ceny6rwEL.jpg",
                  BookDescription = "Learn the secrets to getting dramatic results on YouTube\r\n\r\nDerral Eves has generated over 60 billion views on YouTube and helped twenty-four channels grow to one million subscribers from zero. In The YouTube Formula: How Anyone Can Unlock the Algorithm to Drive Views, Build an Audience, and Grow Revenue, the owner of the largest YouTube how-to channel provides the secrets to getting the results that every YouTube creator and strategist wants. Eves will reveal what listeners can't get anywhere else: the inner workings of the YouTube algorithm that's responsible for determining success on the platform, and how creators can use it to their advantage. \r\n\r\nFull of actionable advice and concrete strategies, this book teaches listeners how to launch a channel, create life-changing content, drive rapid view and subscriber growth, build a brand and increase engagement, improve searchability, and monetize your content and audience.\r\n\r\nReplete with case studies and information from successful YouTube creators, The YouTube Formula is perfect for any creator, entrepreneur, social media strategist, and brand manager who hopes to see real commercial results from their work on the platform.\r\n",
                  CategoryId = 4
              },
              new Book
              {
                  Id = 31,
                  BookId = "B31",
                  BookTitle = "CompTIA Security+",
                  BookQuantity = 8,
                  BookPrice = 39.99,
                  BookAuthor = "Mike Chapple",
                  BookImage = "https://m.media-amazon.com/images/I/41AHmR067ZL._SX435_BO1,204,203,200_.jpg",
                  BookDescription = "Everything you need to prepare for and take the Security+ exam!\r\n\r\nThe CompTIA Security+ Certification Kit includes CompTIA Security+ Study Guide: Exam SY0-601, 8th Edition, and the CompTIA Security+ Practice Tests: Exam SY0-601, 2nd Edition. Together, both books provide comprehensive review for the CompTIA Security+ SY0-601 certification exam. The Kit covers:\r\n\r\nAssessing the security posture of an enterprise environment, and recommending and implementing appropriate security solutions\r\nMonitoring and securing hybrid environments, including cloud, mobile, and IoT\r\nOperating with an awareness of applicable laws and policies, including principles of governance, risk, and compliance\r\nIdentifying, analyzing, and responding to security events and incidents\r\nThe Study Guide has been completely revised to align with the latest version of the exam objectives. The Practice Tests includes hundreds of domain-by-domain questions plus practice exams to test your knowledge of the topics.\r\n",
                  CategoryId = 4
              },
              new Book
              {
                  Id = 32,
                  BookId = "B32",
                  BookTitle = "The Bitcoin Standard",
                  BookQuantity = 16,
                  BookPrice = 17.19,
                  BookAuthor = "Saifedean Ammous",
                  BookImage = "https://m.media-amazon.com/images/I/41x6NvXWekS._SX336_BO1,204,203,200_.jpg",
                  BookDescription = "A comprehensive and authoritative exploration of Bitcoin and its place in monetary history\r\n\r\nWhen a pseudonymous programmer introduced “a new electronic cash system that’s fully peer-to-peer, with no trusted third party” to a small online mailing list in 2008, very few people paid attention. Ten years later, and against all odds, this upstart autonomous decentralized software offers an unstoppable and globally accessible hard money alternative to modern central banks. The Bitcoin Standard analyzes the historical context to the rise of Bitcoin, the economic properties that have allowed it to grow quickly, and its likely economic, political, and social implications.\r\n",
                  CategoryId = 4
              },
              new Book
              {
                  Id = 33,
                  BookId = "B33",
                  BookTitle = "The Chaos Machine",
                  BookQuantity = 22,
                  BookPrice = 24.66,
                  BookAuthor = "Max Fisher",
                  BookImage = "https://m.media-amazon.com/images/I/519INV5bFIL._SX332_BO1,204,203,200_.jpg",
                  BookDescription = "From a New York Times investigative reporter, this “authoritative and devastating account of the impacts of social media” (New York Times Book Review)  tracks the high-stakes inside story of how Big Tech’s breakneck race to drive engagement—and profits—at all costs fractured the world. The Chaos Machine is “an essential book for our times” (Ezra Klein).",
                  CategoryId = 4
              },
              new Book
              {
                  Id = 34,
                  BookId = "B34",
                  BookTitle = "HTML and CSS",
                  BookQuantity = 19,
                  BookPrice = 15.79,
                  BookAuthor = "Jon Duckett",
                  BookImage = "https://m.media-amazon.com/images/I/31b4K-hFH-L._SX395_BO1,204,203,200_.jpg",
                  BookDescription = "A full-color introduction to the basics of HTML and CSS from the publishers of Wrox!\r\nEvery day, more and more people want to learn some HTML and CSS. Joining the professional web designers and programmers are new audiences who need to know a little bit of code at work (update a content management system or e-commerce store) and those who want to make their personal blogs more attractive. Many books teaching HTML and CSS are dry and only written for those who want to become programmers, which is why this book takes an entirely new approach.\r\n\r\nIntroduces HTML and CSS in a way that makes them accessible to everyone―hobbyists, students, and professionals―and it’s full-color throughout\r\nUtilizes information graphics and lifestyle photography to explain the topics in a simple way that is engaging\r\nBoasts a unique structure that allows you to progress through the chapters from beginning to end or just dip into topics of particular interest at your leisure\r\nThis educational book is one that you will enjoy picking up, reading, then referring back to. It will make you wish other technical topics were presented in such a simple, attractive and engaging way!\r\n",
                  CategoryId = 4
              },
              new Book
              {
                  Id = 35,
                  BookId = "B35",
                  BookTitle = "Lean UX",
                  BookQuantity = 26,
                  BookPrice = 20.49,
                  BookAuthor = "Jeff Gothelf",
                  BookImage = "https://m.media-amazon.com/images/I/41LWgFsaBCL.jpg",
                  BookDescription = "Lean UX is synonymous with modern product design and development. By combining human-centric design, agile ways of working, and a strong business sense, designers, product managers, developers, and scrum masters around the world are making Lean UX the leading approach for digital product teams today.\r\n\r\nIn the third edition of this award-winning book, authors Jeff Gothelf and Josh Seiden help you focus on the product experience rather than deliverables. You'll learn tactics for integrating user experience design, product discovery, agile methods, and product management. And you'll discover how to drive your design in short, iterative cycles to assess what works best for businesses and users. Lean UX guides you through this change--for the better.\r\n\r\nFacilitate the Lean UX process with your team with the Lean UX Canvas\r\nEnsure every project starts with clear customer-centric success criteria\r\nUnderstand the role of designer on a agile team\r\nWrite and contribute design and experiment stories to the backlog\r\nEnsure that design work takes place in every sprint\r\nBuild product discovery into your team's \"velocity\"\r\n",
                  CategoryId = 4
              },
              new Book
              {
                  Id = 36,
                  BookId = "B36",
                  BookTitle = "The Art of Micro Frontends",
                  BookQuantity = 4,
                  BookPrice = 41.99,
                  BookAuthor = "Florian Rappl",
                  BookImage = "https://m.media-amazon.com/images/I/415b-pIsGzS._SX404_BO1,204,203,200_.jpg",
                  BookDescription = "Micro frontend is a web architecture for frontend development borrowed from the idea of microservices in software development, where each module of the frontend is developed and shipped in isolation to avoid complexity and a single point of failure for your frontend.\r\n\r\nComplete with hands-on tutorials, projects, and self-assessment questions, this easy-to-follow guide will take you through the patterns available for implementing a micro frontend solution. You'll learn about micro frontends in general, the different architecture styles and their areas of use, how to prepare teams for the change to micro frontends, as well as how to adjust the UI design for scalability. Starting with the simplest variants of micro frontend architectures, the book progresses from static approaches to fully dynamic solutions that allow maximum scalability with faster release cycles. In the concluding chapters, you'll reinforce the knowledge you've gained by working on different case studies relating to micro frontends.\r\n\r\nBy the end of this book, you'll be able to decide if and how micro frontends should be implemented to achieve scalability for your user interface (UI).\r\n",
                  CategoryId = 4
              }
              );
        }



        private void SeedUser(ModelBuilder builder)
        {
            //1. tạo tài khoản ban đầu để add vào DB
            var admin = new IdentityUser
            {
                Id = "1",
                UserName = "ad_leanh",
                Email = "anhltp@fpt.edu.vn",
                NormalizedUserName = "anhltp@fpt.edu.vn",
                EmailConfirmed = true
            };

            var staff = new IdentityUser
            {
                Id = "2",
                UserName = "s_duong",
                Email = "duonghtt@fpt.edu.vn",
                NormalizedUserName = "duonghtt@fpt.edu.vn",
                EmailConfirmed = true
            };
            var customer = new IdentityUser
            {
                Id = "3",
                UserName = "cus_minh",
                Email = "minhlt@gmail.com",
                NormalizedUserName = "minhlt@gmail.com",
                EmailConfirmed = true
            };


            //2. khai báo thư viện để mã hóa mật khẩu
            var hasher = new PasswordHasher<IdentityUser>();

            //3. thiết lập và mã hóa mật khẩu từng tài khoản
            admin.PasswordHash = hasher.HashPassword(admin, "phuong123");
            staff.PasswordHash = hasher.HashPassword(staff, "duong123");
            customer.PasswordHash = hasher.HashPassword(customer, "minh123");
            //4. add tài khoản vào db
            builder.Entity<IdentityUser>().HasData(admin, staff, customer);
        }

        private void SeedRole(ModelBuilder builder)
        {
            var admin = new IdentityRole
            {
                Id = "A",
                Name = "Administrator",
                NormalizedName = "Administrator"
            };
            var staff = new IdentityRole
            {
                Id = "S",
                Name = "Staff",
                NormalizedName = "Staff"
            };
            var customer = new IdentityRole
            {
                Id = "C",
                Name = "Customer",
                NormalizedName = "Customer"
            };

            //2. add role vào trong DB
            builder.Entity<IdentityRole>().HasData(admin, staff, customer);

        }
        private void SeedUserRole(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "1",
                    RoleId = "A"
                },
                new IdentityUserRole<string>
                {
                    UserId = "2",
                    RoleId = "S"
                },
                  new IdentityUserRole<string>
                  {
                      UserId = "3",
                      RoleId = "C"
                  }
             );
        }
    }
}
