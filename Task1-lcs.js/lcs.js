lcs = (a) => {if(!a.length)return '';let m=a.reduce((a,b)=>a.length<=b.length?a:b),x=m.length;for(let l=x;l>0;l--){for(let s=0;s<=x-l;s++){let r=m.slice(s,l);if(a.every(e=>e.includes(r)))return r;}}return '';};console.log(lcs(process.argv.slice(2)));