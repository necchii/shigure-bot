using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace shigureBot.Modules
{
    public class Hello : ModuleBase<SocketCommandContext>
    {
        [Command("About")]
        public async Task Embed()
        {
            EmbedBuilder shigure = new EmbedBuilder();
            shigure.WithAuthor("Requested by: " + Context.User.Username, Context.User.GetAvatarUrl());
            shigure.WithThumbnailUrl("https://i.imgur.com/OzzP7Ha.jpg");
            shigure.WithTitle(":pushpin: About Shigure");
            shigure.WithDescription("Hi, I'm Shigure, a bot programmed by Jiu! \nMy prefix is `~`, type `~help` for a list of my commands ♪~");
            shigure.AddField(":pushpin: Description", "\n• Language: **C#** " +
                "\n• Library: **Discord.NET v1.0.2** " +
                "\n• IDE: **Microsoft Visual Studio 2017** " +
                "\n \nLearn more about my character at the Kancolle Wiki: " + "http://kancolle.wikia.com/wiki/Shigure");
            shigure.WithFooter("Founded 9/2/2018", Context.Client.CurrentUser.GetAvatarUrl());
            shigure.WithColor(Color.Blue);

            await Context.Channel.SendMessageAsync("", false, shigure);
        }

        [Command("Help")]
        public async Task commandlist()
        {
            EmbedBuilder help = new EmbedBuilder();
            help.WithAuthor("Requested by: " + Context.User.Username, Context.User.GetAvatarUrl());
            help.WithThumbnailUrl("https://i.imgur.com/VOQUUX8.png");
            help.WithTitle("• Miscellaneous");
            help.WithDescription("`about` `purgemsg`");
            help.AddField("• Personal Commands", "`johnny` `simon` `darryl` `bill` `kai` `bobby`");
            help.AddField("• NSFW Commands", "`hentai`");

            help.WithColor(Color.Blue);

            await Context.Channel.SendMessageAsync("", false, help);
        }


        [Command("purgemsg", RunMode = RunMode.Async)]
        [Summary("Deletes the specified amount of messages.")]
        [RequireUserPermission(ChannelPermission.ManageMessages)]
        [RequireBotPermission(ChannelPermission.ManageMessages)]
        public async Task PurgeChat(uint amount)
        {
            var messages = await this.Context.Channel.GetMessagesAsync((int)amount + 1).Flatten();

            await this.Context.Channel.DeleteMessagesAsync(messages);
            const int delay = 5000;
            var m = await this.ReplyAsync($"Succesfully deleted {amount} messages!~");
            await Task.Delay(delay);
            await m.DeleteAsync();
        }

        

        [Command("johnny")]
        public async Task johnny()
        {
            await Context.Channel.SendMessageAsync("<@176909767736819712>" + " Yes, Papa?");

            EmbedBuilder johnny = new EmbedBuilder();
            johnny.WithImageUrl("https://cdn.vox-cdn.com/thumbor/rHPQq-tnsgWCq6WvwudX_6Sz6qM=/0x0:2862x1470/1200x675/filters:focal(1203x507:1659x963)/cdn.vox-cdn.com/uploads/chorus_image/image/61079593/Screen_Shot_2018_08_29_at_3.53.57_PM.0.png");

            johnny.WithColor(Color.Blue);
            await Context.Channel.SendMessageAsync("", false, johnny);
        }

        [Command("bobby")]
        public async Task sock()
        {
            await Context.Channel.SendMessageAsync("<@272219090524045322>" + " What? You wear socks in the house? I'm sorry, but that's disgusting. Please don't summon me again.");
            EmbedBuilder disgust = new EmbedBuilder();
            disgust.WithImageUrl("https://i.kym-cdn.com/photos/images/newsfeed/001/398/715/96d.gif");

            disgust.WithColor(Color.Blue);
            await Context.Channel.SendMessageAsync("", false, disgust);
        }

        [Command("simon")]
        public async Task simon()
        {
            await Context.Channel.SendMessageAsync("<@164588930803433472>" + " @What the fuck did you just fucking say about me, you little bitch? " +
                "I'll have you know I graduated top of my class in the Navy Seals, and I've been involved in numerous secret raids on Al-Quaeda, " +
                "and I have over 300 confirmed kills. I am trained in gorilla warfare and I'm the top sniper in the entire US armed forces. " +
                "You are nothing to me but just another target. I will wipe you the fuck out with precision the likes of which has never been seen before on this Earth, mark my fucking words. " +
                "You think you can get away with saying that shit to me over the Internet? Think again, fucker. " +
                "As we speak I am contacting my secret network of spies across the USA and your IP is being traced right now so you better prepare for the storm, maggot. " +
                "The storm that wipes out the pathetic little thing you call your life. You're fucking dead, kid. " +
                "I can be anywhere, anytime, and I can kill you in over seven hundred ways, and that's just with my bare hands. " +
                "Not only am I extensively trained in unarmed combat, but I have access to the entire arsenal of the United States Marine Corps and " +
                "I will use it to its full extent to wipe your miserable ass off the face of the continent, you little shit. If only you could have known what unholy retribution" +
                " your little \"clever\" comment was about to bring down upon you, maybe you would have held your fucking tongue. But you couldn't, you didn't, and now you're " +
                "paying the price, you goddamn idiot. I will shit fury all over you and you will drown in it. You're fucking dead, kiddo.");
        }

        [Command("darryl")]
        public async Task darryl()
        {
            await Context.Channel.SendMessageAsync("<@153001527953457152>" + "ｄｅｓｐａｃｉｔｏ ２");
        }

        [Command("bill")]
        public async Task bill()
        {
            await Context.Channel.SendMessageAsync("<@209380024833409024> " + "Monkey is not b-l-a-c-k");
        }

        [Command("hentai")]
        public async Task hentai()
        {
            await Context.Channel.SendMessageAsync(Context.Message.Author.Mention + " The fuck, nigga?");
        }

        [Command("kai")]
        public async Task kai()
        {
            await Context.Channel.SendMessageAsync("<@174016206603288577>" + " Let this be a lesson that Johnny is a baby back bitch.");
        }

        [Command("ayaya")]
        public async Task ayaya()
        {
            await Context.Channel.SendMessageAsync("Ayaya!");
        }
    }
}
