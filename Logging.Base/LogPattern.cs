using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Logging.Base
{
    public class LogPattern
    {
        private static string[] TextContext =
        {
            "spice-vdagent[3022]: primary: received clipboard data without an outstanding selection request, ignoring",
            "gnome-shell[2821]: JS ERROR: Exception in callback for signal: position-changed: TypeError: this._rect is undefined#012getCurrentRect@resource:///org/gnome/shell/ui/keyboard.js:546:22#012wrapper@resource:///org/gnome/gjs/modules/_legacy.js:82:22#012_onFocusPositionChanged@resource:///org/gnome/shell/ui/keyboard.js:611:20#012wrapper@resource:///org/gnome/gjs/modules/_legacy.js:82:22#012_emit@resource:///org/gnome/gjs/modules/signals.js:128:27#012_setCurrentWindow/this._currentWindowPositionId<@resource:///org/gnome/shell/ui/keyboard.js:528:21",
            "dbus-daemon[2666]: [session uid=1000 pid=2666] Activating service name='org.gnome.Nautilus' requested by ':1.23' (uid=1000 pid=2821 comm=\"/usr/bin/gnome-shell \" label=\"unconfined\")",
            "dbus-daemon[2666]: [session uid=1000 pid=2666] Successfully activated service 'org.gnome.Nautilus'",
            "dbus-daemon[842]: [system] Activating via systemd: service name='org.freedesktop.hostname1' unit='dbus-org.freedesktop.hostname1.service' requested by ':1.117' (uid=1000 pid=7410 comm=\"/usr/bin/nautilus --gapplication-service \" label=\"unconfined\")",
            "systemd[1]: Starting Hostname Service...",
            "nautilus[7410]: Called \"net usershare info\" but it failed: Failed to execute child process “net” (No such file or directory)",
            "dbus-daemon[842]: [system] Successfully activated service 'org.freedesktop.hostname1'",
            "systemd[1]: Started Hostname Service.",
            "gsd-color[2992]: unable to get EDID for xrandr-Virtual-0: unable to get EDID for output",
            "dbus-daemon[2666]: [session uid=1000 pid=2666] Activating via systemd: service name='org.gnome.zeitgeist.Engine' unit='zeitgeist.service' requested by ':1.80' (uid=1000 pid=7410 comm=\"/usr/bin/nautilus --gapplication-service \" label=\"unconfined\")",
            "systemd[2614]: Starting Zeitgeist activity log service...",
            "dbus-daemon[2666]: [session uid=1000 pid=2666] Activating via systemd: service name='org.gnome.zeitgeist.SimpleIndexer' unit='zeitgeist-fts.service' requested by ':1.81' (uid=1000 pid=7447 comm=\"/usr/bin/zeitgeist-daemon \" label=\"unconfined\")",
            "dbus-daemon[2666]: [session uid=1000 pid=2666] Successfully activated service 'org.gnome.zeitgeist.Engine'",
            "systemd[2614]: Started Zeitgeist activity log service.",
            "systemd[2614]: Starting Zeitgeist full-text search indexer...",
            "zeitgeist-daemon[7447]: #033[31m[01:54:43.442566 WARNING]#033[0m zeitgeist-daemon.vala:334: Failed to execute child process “zeitgeist-datahub” (No such file or directory)",
            "zeitgeist-daemon[7447]: #033[31m[01:54:43.442670 WARNING]#033[0m zeitgeist-daemon.vala:127: Unable to parse version info!",
            "zeitgeist-daemon[7447]: #033[31m[01:54:43.442730 WARNING]#033[0m zeitgeist-daemon.vala:127: Unable to parse version info!",
            "dbus-daemon[2666]: [session uid=1000 pid=2666] Successfully activated service 'org.gnome.zeitgeist.SimpleIndexer'",
            "systemd[2614]: Started Zeitgeist full-text search indexer.",
            "gnome-shell[2821]: JS ERROR: Exception in callback for signal: position-changed: TypeError: this._rect is undefined#012getCurrentRect@resource:///org/gnome/shell/ui/keyboard.js:546:22#012wrapper@resource:///org/gnome/gjs/modules/_legacy.js:82:22#012_onFocusPositionChanged@resource:///org/gnome/shell/ui/keyboard.js:611:20#012wrapper@resource:///org/gnome/gjs/modules/_legacy.js:82:22#012_emit@resource:///org/gnome/gjs/modules/signals.js:128:27#012_setCurrentWindow/this._currentWindowPositionId<@resource:///org/gnome/shell/ui/keyboard.js:528:21",
            "dbus-daemon[2666]: [session uid=1000 pid=2666] Activating service name='org.gnome.Nautilus' requested by ':1.23' (uid=1000 pid=2821 comm=\"/usr/bin/gnome-shell \" label=\"unconfined\")",
            "dbus-daemon[2666]: [session uid=1000 pid=2666] Successfully activated service 'org.gnome.Nautilus'",
            "dbus-daemon[842]: [system] Activating via systemd: service name='org.freedesktop.hostname1' unit='dbus-org.freedesktop.hostname1.service' requested by ':1.120' (uid=1000 pid=7787 comm=\"/usr/bin/nautilus --gapplication-service \" label=\"unconfined\")",
            "systemd[1]: Starting Hostname Service...",
            "nautilus[7787]: Called \"net usershare info\" but it failed: Failed to execute child process “net” (No such"
        };

        private static int Count = 100;

        public static void DoLog(Action<string> action)
        {
            int? c = null;
            DoLog(c, action);
        }

        public static void DoLog(string[] args, Action<string> action)
        {
            int? c = null;

            if (args.Length > 0 && int.TryParse(args[0], out int cout) && cout > 0)
            {
                c = cout;
            }

            DoLog(c, action);
        }

        public static void DoLog(int? count, Action<string> action)
        {
            count = count ?? Count;

            using (var contents = LogContents().GetEnumerator())
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                for (int i = 0; i < count; i++)
                {
                    contents.MoveNext();
                    action.Invoke(contents.Current);
                }

                stopwatch.Stop();
                Console.WriteLine($"Time used: {stopwatch.Elapsed}");
            }
        }

        private static IEnumerable<string> LogContents()
        {
            int i = 0;
            int size = TextContext.Length;
            while (true)
            {
                yield return TextContext[i++ % size];
            }
        }
    }
}