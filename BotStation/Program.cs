using BotStation.Cli;
using BotStation.DependancyInjector;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using System;
using System.Drawing;
using System.Drawing.Imaging;

var inputReader = new InputReader();

inputReader.BeginWaitForInput();