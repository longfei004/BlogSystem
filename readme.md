# 主要修改

1. 在DataAccess中建立BlogEntity模型用于持久化；
2. 在Business中建立Blog模型，作为domain model;
3. 为了做BlogEntity与Blog的映射，在Business中添加对BlogEntity的扩展方法ToBlog();
4. 为了做Blog到BlogEntity的映射，在Blog中添加ToBlogEntity()方法，不确定是否写为扩展方法。