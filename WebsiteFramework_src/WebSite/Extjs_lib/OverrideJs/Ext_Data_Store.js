
Ext.data.Store.prototype.remove = function(record){
	if(Ext.isArray(record)){
		Ext.each(record, function(r){
			this.remove(r);
		}, this);
	}
	var index = this.data.indexOf(record);
	if(index > -1){
		record.join(null);
		this.data.removeAt(index);

	}
	
	//remove recoed from proxy
	//added by jar on 2009-12-28
	if (this.proxy.data){
	  for (i = 0 ; i < this.proxy.data.items.length; i ++){
		  if (this.proxy.data.items[i][this.proxy.data.identifier] == record.data[this.proxy.data.identifier]) {
			  this.proxy.data.items.remove(this.proxy.data.items[i]);
			  this.proxy.data.totalProperty --;
			  this.totalLength --;
		  }
	  }
	}

	if(this.pruneModifiedRecords){
		this.modified.remove(record);
	}
	if(this.snapshot){
		this.snapshot.remove(record);
	}
	if(index > -1){
		this.fireEvent('remove', this, record, index);
	}
};

Ext.data.Store.prototype.removeAll = function(silent){
	var items = [];
	this.each(function(rec){
		items.push(rec);
	});
	this.clearData();

	//remove recoeds from proxy
	//added by jar on 2009-12-28
	if (this.proxy.data){
	  for (i = this.proxy.data.items.length - 1 ; i >= 0; i --) {
		  this.proxy.data.items.remove(this.proxy.data.items[i]);
		  this.proxy.data.totalProperty --;
		  this.totalLength --;
	  }
	}

	if(this.snapshot){
		this.snapshot.clear();
	}
	if(this.pruneModifiedRecords){
		this.modified = [];
	}
	if (silent !== true) {  // <-- prevents write-actions when we just want to clear a store.
		this.fireEvent('clear', this, items);
	}
}