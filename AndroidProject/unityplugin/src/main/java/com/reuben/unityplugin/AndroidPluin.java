package com.reuben.unityplugin;

import android.util.Log;
import android.app.DatePickerDialog;
/**
 * Created by reuben.coutinho on 26/9/17.
 */

public class AndroidPluin {

    DatePickerDialog diag ;
    private static OnDateSetListener listener;

    public AndroidPluin(OnDateSetListener listener){
        this.listener = listener;
    }

    public static String getTextFromPluginStatic(int number){
        Log.d("AndroidPluin","getTextFromPluginStatic = "+number);
        return "return static number is "+number;
    }

    public void getMessageCallback(){
        Log.d("AndroidPluin","getMessageCallback");
        this.listener.CallFunc();
    }

    public String getTextFromPlugin(int number){
        Log.d("AndroidPluin","getTextFromPlugin = "+number);
        return "return number is "+number;
    }

}
