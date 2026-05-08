/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:7336933
*  Stack Overflow answer #:7410624
*  And Stack Overflow answer#:7410624
*/
private void next_item () {
    if (scrip_index < script_list.Count () - 1) {
        scrip_index ++;
        switch (script_list [scrip_index].action) {
            case "Load" :
                mediaElement1.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
                mediaElement1.UnloadedBehavior = System.Windows.Controls.MediaState.Manual;
                if (mediaElement1.Source != new Uri (script_list [scrip_index].filename))
                    mediaElement1.Source = new Uri (script_list [scrip_index].filename);
                mediaElement1.ScrubbingEnabled = true;
                playing = false;
                next_item ();
                break;
            case "Play" :
                mediaElement1.Play ();
                playing = true;
                if (! test_position.IsBusy)
                    test_position.RunWorkerAsync ();
                break;
            case "Pause" :
                mediaElement1.Pause ();
                playing = false;
                break;
            case "Seek" :
                mediaElement1.Position = script_list [scrip_index].start_time;
                playing = true;
                break;
            case "Stop" :
                mediaElement1.Stop ();
                playing = false;
                break;
        }
    }
}

private void testbutton_Click (object sender, RoutedEventArgs e) {
    if (mediaElement1.Source != new Uri (tb_filename.Text))
        mediaElement1.Source = new Uri (tb_filename.Text);
    mediaElement1.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
    mediaElement1.UnloadedBehavior = System.Windows.Controls.MediaState.Manual;
    mediaElement1.Play ();
    mediaElement1.ScrubbingEnabled = true;
    mediaElement1.Position = TimeSpan.FromMilliseconds (Convert.ToInt32 (tb_starttime.Text));
    if (test_position.IsBusy)
        test_position.CancelAsync ();
    if (! test_position.IsBusy)
        test_position.RunWorkerAsync ();
}

