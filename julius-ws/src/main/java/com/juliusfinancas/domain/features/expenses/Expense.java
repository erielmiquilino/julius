package com.juliusfinancas.domain;

import com.juliusfinancas.domain.common.BaseEntity;

import java.math.BigDecimal;
import java.time.LocalDate;

public class Expense extends BaseEntity {

    private LocalDate dueDate;

    private String description;

    private BigDecimal totalPayable;

}
