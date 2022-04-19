--取得Table資料
select 
   a.table_name,
   b.comments 
 from user_tables a,user_tab_comments b 
 where a.TABLE_NAME=b.table_name(+) 
 order by a.TABLE_NAME 


SELECT a.column_id "ordinal_position",
         a.column_name,
         c.comments,
         a.data_type,
         a.nullable,
         a.data_default "default",
         COALESCE(a.data_precision, a.data_length) "length",
         a.data_scale "scale"
    FROM all_tab_columns a,user_col_comments c
   WHERE a.TABLE_NAME=c.table_name(+) and a.COLUMN_NAME=c.column_name(+)
   and   a.table_name = 'ACCT' and a.OWNER='CAERDSA'
ORDER BY column_id



--取得fk pk 
      
      /*SELECT alc.constraint_name,
          CASE alc.constraint_type
            WHEN 'P' THEN 'PRIMARY KEY'
            WHEN 'R' THEN 'FOREIGN KEY'
            WHEN 'U' THEN 'UNIQUE'
            WHEN 'C' THEN 'CHECK'
          END "constraint_type",
          alc.DELETE_RULE "on_delete",
          CASE alc.deferrable WHEN 'NOT DEFERRABLE' THEN 0 ELSE 1 END "deferrable",
          CASE alc.deferred WHEN 'IMMEDIATE' THEN 1 ELSE 0 END "initially_deferred",
          alc.search_condition,
          alc.table_name,
          cols.column_name,
          cols.position,
          r_alc.table_name "references_table",
          r_cols.column_name "references_field",
          r_cols.position "references_field_position"
     FROM all_cons_columns cols
LEFT JOIN all_constraints alc
       ON alc.constraint_name = cols.constraint_name
      AND alc.owner = cols.owner
LEFT JOIN all_constraints r_alc
       ON alc.r_constraint_name = r_alc.constraint_name
      AND alc.r_owner = r_alc.owner
LEFT JOIN all_cons_columns r_cols
       ON r_alc.constraint_name = r_cols.constraint_name
      AND r_alc.owner = r_cols.owner
      AND cols.position = r_cols.position
    WHERE alc.constraint_name = cols.constraint_name
      --AND alc.constraint_name = 'FK_TESTUSER'
      AND alc.table_name = 'TESTUSER';*/
      
      
      
      


