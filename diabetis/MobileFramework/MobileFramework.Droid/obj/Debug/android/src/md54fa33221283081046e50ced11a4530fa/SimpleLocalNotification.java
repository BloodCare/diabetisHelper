package md54fa33221283081046e50ced11a4530fa;


public class SimpleLocalNotification
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MobileFramework.Droid.Services.SimpleLocalNotification, MobileFramework.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", SimpleLocalNotification.class, __md_methods);
	}


	public SimpleLocalNotification () throws java.lang.Throwable
	{
		super ();
		if (getClass () == SimpleLocalNotification.class)
			mono.android.TypeManager.Activate ("MobileFramework.Droid.Services.SimpleLocalNotification, MobileFramework.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
