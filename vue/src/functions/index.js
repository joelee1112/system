export const alertError = a => {
  alert('系統發生錯誤：\n' +
    Object.entries(a.body)
    .map(b => {
      return b[1].join("\n");
    })
    .join("\n")
  );
}
